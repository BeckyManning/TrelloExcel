﻿namespace TrelloExcelAddIn
{
	partial class ExportCardsControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.AddCardsGroupBox = new System.Windows.Forms.GroupBox();
			this.StatusLabel = new System.Windows.Forms.Label();
			this.AddCardsButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.ListComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.BoardComboBox = new System.Windows.Forms.ComboBox();
			this.FetchBoardsButton = new System.Windows.Forms.Button();
			this.AddCardsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// AddCardsGroupBox
			// 
			this.AddCardsGroupBox.Controls.Add(this.StatusLabel);
			this.AddCardsGroupBox.Controls.Add(this.AddCardsButton);
			this.AddCardsGroupBox.Controls.Add(this.label2);
			this.AddCardsGroupBox.Controls.Add(this.ListComboBox);
			this.AddCardsGroupBox.Controls.Add(this.label1);
			this.AddCardsGroupBox.Controls.Add(this.BoardComboBox);
			this.AddCardsGroupBox.Location = new System.Drawing.Point(8, 41);
			this.AddCardsGroupBox.Name = "AddCardsGroupBox";
			this.AddCardsGroupBox.Size = new System.Drawing.Size(256, 115);
			this.AddCardsGroupBox.TabIndex = 11;
			this.AddCardsGroupBox.TabStop = false;
			this.AddCardsGroupBox.Text = "Choose list";
			// 
			// StatusLabel
			// 
			this.StatusLabel.AutoSize = true;
			this.StatusLabel.Location = new System.Drawing.Point(5, 86);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(0, 13);
			this.StatusLabel.TabIndex = 13;
			// 
			// AddCardsButton
			// 
			this.AddCardsButton.Location = new System.Drawing.Point(156, 81);
			this.AddCardsButton.Name = "AddCardsButton";
			this.AddCardsButton.Size = new System.Drawing.Size(81, 23);
			this.AddCardsButton.TabIndex = 12;
			this.AddCardsButton.Text = "Export cards";
			this.AddCardsButton.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(23, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "List";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ListComboBox
			// 
			this.ListComboBox.FormattingEnabled = true;
			this.ListComboBox.Location = new System.Drawing.Point(43, 54);
			this.ListComboBox.Name = "ListComboBox";
			this.ListComboBox.Size = new System.Drawing.Size(194, 21);
			this.ListComboBox.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Board";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// BoardComboBox
			// 
			this.BoardComboBox.FormattingEnabled = true;
			this.BoardComboBox.Location = new System.Drawing.Point(43, 24);
			this.BoardComboBox.Name = "BoardComboBox";
			this.BoardComboBox.Size = new System.Drawing.Size(194, 21);
			this.BoardComboBox.TabIndex = 8;
			// 
			// FetchBoardsButton
			// 
			this.FetchBoardsButton.Location = new System.Drawing.Point(179, 12);
			this.FetchBoardsButton.Name = "FetchBoardsButton";
			this.FetchBoardsButton.Size = new System.Drawing.Size(85, 23);
			this.FetchBoardsButton.TabIndex = 14;
			this.FetchBoardsButton.Text = "Fetch boards";
			this.FetchBoardsButton.UseVisualStyleBackColor = true;
			// 
			// ExportCardsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.FetchBoardsButton);
			this.Controls.Add(this.AddCardsGroupBox);
			this.Name = "ExportCardsControl";
			this.Size = new System.Drawing.Size(273, 172);
			this.AddCardsGroupBox.ResumeLayout(false);
			this.AddCardsGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox AddCardsGroupBox;
		private System.Windows.Forms.Button AddCardsButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox ListComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox BoardComboBox;
		private System.Windows.Forms.Label StatusLabel;
		private System.Windows.Forms.Button FetchBoardsButton;

	}
}