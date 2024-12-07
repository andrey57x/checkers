namespace Checkers
{
    partial class PlayingForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainTable = new TableLayoutPanel();
            FieldTable = new TableLayoutPanel();
            HistoryTable = new TableLayoutPanel();
            BlackLabel = new Label();
            WhiteLabel = new Label();
            MainTable.SuspendLayout();
            HistoryTable.SuspendLayout();
            SuspendLayout();
            // 
            // MainTable
            // 
            MainTable.ColumnCount = 2;
            MainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            MainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            MainTable.Controls.Add(HistoryTable, 1, 0);
            MainTable.Controls.Add(FieldTable, 0, 0);
            MainTable.Dock = DockStyle.Fill;
            MainTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            MainTable.Location = new Point(0, 0);
            MainTable.Name = "MainTable";
            MainTable.RowCount = 1;
            MainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            MainTable.Size = new Size(1064, 681);
            MainTable.TabIndex = 0;
            // 
            // FieldTable
            // 
            FieldTable.Anchor = AnchorStyles.None;
            FieldTable.ColumnCount = 8;
            FieldTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            FieldTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            FieldTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            FieldTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            FieldTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            FieldTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            FieldTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            FieldTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            FieldTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            FieldTable.Location = new Point(199, 64);
            FieldTable.Margin = new Padding(0);
            FieldTable.Name = "FieldTable";
            FieldTable.RowCount = 8;
            FieldTable.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            FieldTable.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            FieldTable.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            FieldTable.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            FieldTable.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            FieldTable.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            FieldTable.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            FieldTable.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            FieldTable.Size = new Size(452, 553);
            FieldTable.TabIndex = 1;
            // 
            // HistoryTable
            // 
            HistoryTable.AutoScroll = true;
            HistoryTable.ColumnCount = 2;
            HistoryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            HistoryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            HistoryTable.Controls.Add(BlackLabel, 1, 0);
            HistoryTable.Controls.Add(WhiteLabel, 0, 0);
            HistoryTable.Location = new Point(854, 3);
            HistoryTable.Name = "HistoryTable";
            HistoryTable.RowCount = 2;
            HistoryTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            HistoryTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            HistoryTable.Size = new Size(207, 675);
            HistoryTable.TabIndex = 0;
            // 
            // BlackLabel
            // 
            BlackLabel.AutoSize = true;
            BlackLabel.Dock = DockStyle.Fill;
            BlackLabel.Font = new Font("Segoe UI", 20F);
            BlackLabel.Location = new Point(106, 0);
            BlackLabel.Name = "BlackLabel";
            BlackLabel.Size = new Size(98, 80);
            BlackLabel.TabIndex = 1;
            BlackLabel.Text = "Black";
            BlackLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WhiteLabel
            // 
            WhiteLabel.AutoSize = true;
            WhiteLabel.Dock = DockStyle.Fill;
            WhiteLabel.Font = new Font("Segoe UI", 20F);
            WhiteLabel.Location = new Point(3, 0);
            WhiteLabel.Name = "WhiteLabel";
            WhiteLabel.Size = new Size(97, 80);
            WhiteLabel.TabIndex = 0;
            WhiteLabel.Text = "White";
            WhiteLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PlayingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 681);
            Controls.Add(MainTable);
            Name = "PlayingForm";
            Text = "The Best Game Ever";
            MainTable.ResumeLayout(false);
            HistoryTable.ResumeLayout(false);
            HistoryTable.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel MainTable;
        private TableLayoutPanel HistoryTable;
        private Label BlackLabel;
        private Label WhiteLabel;
        private TableLayoutPanel FieldTable;
    }
}