namespace Sudoku
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            PlayButtonMain = new RoundButton();
            SudokuMainLabel = new RoundedLabel();
            LevelLabel = new RoundedLabel();
            HistoryButton = new RoundButton();
            SuspendLayout();
            // 
            // PlayButtonMain
            // 
            PlayButtonMain.Anchor = AnchorStyles.None;
            PlayButtonMain.BackColor = Color.Gray;
            PlayButtonMain.Font = new Font("Showcard Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PlayButtonMain.ForeColor = Color.Plum;
            PlayButtonMain.Image = (Image)resources.GetObject("PlayButtonMain.Image");
            PlayButtonMain.ImageAlign = ContentAlignment.MiddleRight;
            PlayButtonMain.Location = new Point(121, 288);
            PlayButtonMain.Name = "PlayButtonMain";
            PlayButtonMain.Size = new Size(278, 92);
            PlayButtonMain.TabIndex = 0;
            PlayButtonMain.Text = "PLAY";
            PlayButtonMain.TextImageRelation = TextImageRelation.TextBeforeImage;
            PlayButtonMain.UseVisualStyleBackColor = false;
            PlayButtonMain.Click += StartGame;
            // 
            // SudokuMainLabel
            // 
            SudokuMainLabel.Anchor = AnchorStyles.None;
            SudokuMainLabel.BackColor = Color.Gray;
            SudokuMainLabel.Font = new Font("Showcard Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SudokuMainLabel.ForeColor = Color.Plum;
            SudokuMainLabel.Location = new Point(121, 50);
            SudokuMainLabel.Name = "SudokuMainLabel";
            SudokuMainLabel.Size = new Size(278, 81);
            SudokuMainLabel.TabIndex = 1;
            SudokuMainLabel.Text = "SUDOKU";
            // 
            // LevelLabel
            // 
            LevelLabel.AutoSize = true;
            LevelLabel.BackColor = Color.Gray;
            LevelLabel.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LevelLabel.ForeColor = Color.Plum;
            LevelLabel.Location = new Point(205, 235);
            LevelLabel.Name = "LevelLabel";
            LevelLabel.Size = new Size(102, 37);
            LevelLabel.TabIndex = 2;
            LevelLabel.Text = "Level";
            // 
            // HistoryButton
            // 
            HistoryButton.BackColor = Color.Gray;
            HistoryButton.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HistoryButton.ForeColor = Color.Plum;
            HistoryButton.Location = new Point(162, 148);
            HistoryButton.Name = "HistoryButton";
            HistoryButton.Size = new Size(207, 47);
            HistoryButton.TabIndex = 3;
            HistoryButton.Text = "Game history";
            HistoryButton.UseVisualStyleBackColor = false;
            HistoryButton.Click += HistoryButton_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(534, 421);
            Controls.Add(HistoryButton);
            Controls.Add(LevelLabel);
            Controls.Add(SudokuMainLabel);
            Controls.Add(PlayButtonMain);
            ForeColor = Color.FromArgb(224, 224, 224);
            Name = "MainMenu";
            Padding = new Padding(50);
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundButton PlayButtonMain;
        private RoundedLabel SudokuMainLabel;
        private RoundedLabel LevelLabel;
        private RoundButton HistoryButton;
    }
}
