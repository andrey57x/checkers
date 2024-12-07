namespace Checkers
{
    partial class MenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DifficultyChooseBox = new GroupBox();
            HardDifficultyButton = new RadioButton();
            NormalDifficultyButton = new RadioButton();
            EasyDifficultyButton = new RadioButton();
            Label = new Label();
            SideChooseBox = new GroupBox();
            BlackButton = new RadioButton();
            WhiteButton = new RadioButton();
            StartGameButton = new Button();
            DifficultyChooseBox.SuspendLayout();
            SideChooseBox.SuspendLayout();
            SuspendLayout();
            // 
            // DifficultyChooseBox
            // 
            DifficultyChooseBox.Controls.Add(HardDifficultyButton);
            DifficultyChooseBox.Controls.Add(NormalDifficultyButton);
            DifficultyChooseBox.Controls.Add(EasyDifficultyButton);
            DifficultyChooseBox.Font = new Font("Segoe UI", 18F);
            DifficultyChooseBox.Location = new Point(380, 300);
            DifficultyChooseBox.Name = "DifficultyChooseBox";
            DifficultyChooseBox.Size = new Size(240, 200);
            DifficultyChooseBox.TabIndex = 2;
            DifficultyChooseBox.TabStop = false;
            DifficultyChooseBox.Text = "Choose Difficulty";
            // 
            // HardDifficultyButton
            // 
            HardDifficultyButton.AutoSize = true;
            HardDifficultyButton.Location = new Point(10, 150);
            HardDifficultyButton.Name = "HardDifficultyButton";
            HardDifficultyButton.Size = new Size(83, 36);
            HardDifficultyButton.TabIndex = 2;
            HardDifficultyButton.TabStop = true;
            HardDifficultyButton.Tag = "2";
            HardDifficultyButton.Text = "Hard";
            HardDifficultyButton.UseVisualStyleBackColor = true;
            // 
            // NormalDifficultyButton
            // 
            NormalDifficultyButton.AutoSize = true;
            NormalDifficultyButton.Location = new Point(10, 100);
            NormalDifficultyButton.Name = "NormalDifficultyButton";
            NormalDifficultyButton.Size = new Size(111, 36);
            NormalDifficultyButton.TabIndex = 1;
            NormalDifficultyButton.TabStop = true;
            NormalDifficultyButton.Tag = "1";
            NormalDifficultyButton.Text = "Normal";
            NormalDifficultyButton.UseVisualStyleBackColor = true;
            // 
            // EasyDifficultyButton
            // 
            EasyDifficultyButton.AutoSize = true;
            EasyDifficultyButton.Location = new Point(10, 50);
            EasyDifficultyButton.Name = "EasyDifficultyButton";
            EasyDifficultyButton.Size = new Size(78, 36);
            EasyDifficultyButton.TabIndex = 0;
            EasyDifficultyButton.TabStop = true;
            EasyDifficultyButton.Tag = "0";
            EasyDifficultyButton.Text = "Easy";
            EasyDifficultyButton.UseVisualStyleBackColor = true;
            // 
            // Label
            // 
            Label.Dock = DockStyle.Top;
            Label.Font = new Font("Papyrus", 40F);
            Label.Location = new Point(0, 0);
            Label.Name = "Label";
            Label.Size = new Size(1064, 80);
            Label.TabIndex = 0;
            Label.Text = "I want to play a game";
            Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SideChooseBox
            // 
            SideChooseBox.Controls.Add(BlackButton);
            SideChooseBox.Controls.Add(WhiteButton);
            SideChooseBox.Font = new Font("Segoe UI", 18F);
            SideChooseBox.Location = new Point(380, 120);
            SideChooseBox.Name = "SideChooseBox";
            SideChooseBox.Size = new Size(240, 140);
            SideChooseBox.TabIndex = 1;
            SideChooseBox.TabStop = false;
            SideChooseBox.Text = "Choose your side";
            // 
            // BlackButton
            // 
            BlackButton.AutoSize = true;
            BlackButton.Location = new Point(10, 95);
            BlackButton.Name = "BlackButton";
            BlackButton.Size = new Size(87, 36);
            BlackButton.TabIndex = 1;
            BlackButton.TabStop = true;
            BlackButton.Tag = "-1";
            BlackButton.Text = "Black";
            BlackButton.UseVisualStyleBackColor = true;
            // 
            // WhiteButton
            // 
            WhiteButton.AutoSize = true;
            WhiteButton.Location = new Point(10, 50);
            WhiteButton.Name = "WhiteButton";
            WhiteButton.Size = new Size(95, 36);
            WhiteButton.TabIndex = 0;
            WhiteButton.TabStop = true;
            WhiteButton.Tag = "1";
            WhiteButton.Text = "White";
            WhiteButton.UseVisualStyleBackColor = true;
            // 
            // StartGameButton
            // 
            StartGameButton.Font = new Font("Segoe UI", 20F);
            StartGameButton.Location = new Point(450, 550);
            StartGameButton.Name = "StartGameButton";
            StartGameButton.Size = new Size(100, 50);
            StartGameButton.TabIndex = 3;
            StartGameButton.Text = "Start";
            StartGameButton.UseVisualStyleBackColor = true;
            StartGameButton.Click += StartGameButton_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 681);
            Controls.Add(StartGameButton);
            Controls.Add(Label);
            Controls.Add(DifficultyChooseBox);
            Controls.Add(SideChooseBox);
            Name = "MenuForm";
            Text = "Menu";
            TransparencyKey = Color.FromArgb(0, 0, 0, 255);
            DifficultyChooseBox.ResumeLayout(false);
            DifficultyChooseBox.PerformLayout();
            SideChooseBox.ResumeLayout(false);
            SideChooseBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox DifficultyChooseBox;
        private RadioButton HardDifficultyButton;
        private RadioButton NormalDifficultyButton;
        private RadioButton EasyDifficultyButton;
        private Label Label;
        private GroupBox SideChooseBox;
        private RadioButton BlackButton;
        private RadioButton WhiteButton;
        private Button StartGameButton;
    }
}
