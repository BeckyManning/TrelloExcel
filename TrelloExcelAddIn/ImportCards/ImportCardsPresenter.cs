﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using TrelloNet;

namespace TrelloExcelAddIn
{
    public class ImportCardsPresenter
    {
        private readonly IImportCardsView view;
        private readonly IMessageBus messageBus;
        private readonly TrelloHelper trelloHelper;
        private readonly ITrello trello;
        private readonly TaskScheduler taskScheduler;

        public ImportCardsPresenter(IImportCardsView view, IMessageBus messageBus, ITrello trello, TaskScheduler taskScheduler)
        {
            this.view = view;
            this.messageBus = messageBus;
            this.trello = trello;
            this.taskScheduler = taskScheduler;
            trelloHelper = new TrelloHelper(trello);

            SetupMessageEventHandlers();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            view.BoardWasSelected += BoardWasSelected;
            view.ListItemCheckedChanged += ListItemCheckedChanged;
            view.ImportCardsButtonWasClicked += ImportCardsButtonWasClicked;
        }

        private void ImportCardsButtonWasClicked(object sender, EventArgs eventArgs)
        {
            trello.Async.Cards.ForBoard(view.SelectedBoard, BoardCardFilter.Open)
                .ContinueWith(t =>
                {
                    // We should only import cards in lists the user selected
                    var cardsToImport = GetCardsForSelectedLists(t.Result);

                    // Create a range based on the current selection. Rows = number of cards, Columns = 3 (to fit name, desc and due date)
                    var rangeThatFitsAllCards = ResizeToFitAllCards(Globals.ThisAddIn.Application.ActiveWindow.RangeSelection, cardsToImport);

                    // Store the address of this range for later user
                    var addressToFirstCell = rangeThatFitsAllCards.AddressLocal;

                    // Kind of copy/paste this range
                    InsertRange(rangeThatFitsAllCards);

                    // The rangeThatFitsAllCards was change after the InsertRange call, so create a new range based on addressToFirstCell
                    rangeThatFitsAllCards = ResizeToFitAllCards(Globals.ThisAddIn.Application.ActiveSheet.Range(addressToFirstCell), cardsToImport);

                    // Set the values of the cells to the cards name, desc and due date
                    UpdateRangeWithCardsToImport(rangeThatFitsAllCards, cardsToImport);
                });
        }

        private static void UpdateRangeWithCardsToImport(Range rangeThatFitsAllCards, IEnumerable<Card> cardsToImport)
        {
            rangeThatFitsAllCards.Value2 = cardsToImport.Select(c => new [] { c.Name, c.Desc, c.Due.ToString() }).ToArray().ToMultidimensionalArray();
            rangeThatFitsAllCards.Select();
            rangeThatFitsAllCards.Columns.AutoFit();            
        }

        private static void InsertRange(Range rangeThatFitsAllCards)
        {
            rangeThatFitsAllCards.Copy();
            Globals.ThisAddIn.Application.CutCopyMode = XlCutCopyMode.xlCopy;
            rangeThatFitsAllCards.Insert(XlInsertShiftDirection.xlShiftDown);
        }

        private static Range ResizeToFitAllCards(Range rangeSelection, IEnumerable<Card> cardsToImport)
        {
            return rangeSelection.Resize[cardsToImport.Count(), 3];
        }

        private IEnumerable<Card> GetCardsForSelectedLists(IEnumerable<Card> allCards)
        {
            var cards = allCards.Where(c => view.CheckedLists.Select(cl => cl.Id).Contains(c.IdList)).ToList();
            return cards;
        }

        private void ListItemCheckedChanged(object sender, EventArgs eventArgs)
        {
            view.EnableImport = view.CheckedLists.Any();
        }

        private void BoardWasSelected(object sender, EventArgs e)
        {
            trello.Async.Lists.ForBoard(view.SelectedBoard)
                .ContinueWith(t =>
                {
                    if (t.Exception == null)
                    {
                        view.DisplayLists(t.Result);
                        view.EnableSelectionOfLists = true;
                    }
                    else
                    {
                        HandleException(t.Exception);
                    }
                }, taskScheduler);
        }

        private void SetupMessageEventHandlers()
        {
            messageBus.Subscribe<TrelloWasAuthorizedEvent>(_ => FetchAndDisplayBoards());
        }

        private void FetchAndDisplayBoards()
        {
            Task.Factory.StartNew(() => trelloHelper.FetchBoardViewModelsForMe())
            .ContinueWith(t =>
            {
                if (t.Exception == null)
                {
                    view.DisplayBoards(t.Result);
                    view.EnableSelectionOfBoards = true;
                }
                else
                {
                    HandleException(t.Exception);
                }
            }, taskScheduler);
        }

        private void HandleException(AggregateException exception)
        {
        }
    }
}