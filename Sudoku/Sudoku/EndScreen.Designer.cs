using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public partial class EndScreen
    {
        private void InitializeComponent()
        {
            EndPictureBox = new PictureBox();
            AgainButton = new RoundButton();
            EndToMenuButton = new RoundButton();
            EndLevelLabel = new RoundedLabel();
            ((System.ComponentModel.ISupportInitialize)EndPictureBox).BeginInit();
            SuspendLayout();
            // 
            // EndPictureBox
            // 
            EndPictureBox.Location = new Point(45, 36);
            EndPictureBox.Name = "EndPictureBox";
            EndPictureBox.Size = new Size(416, 291);
            EndPictureBox.TabIndex = 0;
            EndPictureBox.TabStop = false;
            // 
            // AgainButton
            // 
            AgainButton.BackColor = Color.Gray;
            AgainButton.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AgainButton.ForeColor = Color.Plum;
            AgainButton.Location = new Point(95, 414);
            AgainButton.Name = "AgainButton";
            AgainButton.Size = new Size(314, 86);
            AgainButton.TabIndex = 1;
            AgainButton.Text = "Try Again!";
            AgainButton.UseVisualStyleBackColor = false;
            AgainButton.Click += AgainButton_Click;
            // 
            // EndToMenuButton
            // 
            EndToMenuButton.BackColor = Color.Gray;
            EndToMenuButton.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EndToMenuButton.ForeColor = Color.Plum;
            EndToMenuButton.Location = new Point(154, 517);
            EndToMenuButton.Name = "EndToMenuButton";
            EndToMenuButton.Size = new Size(198, 52);
            EndToMenuButton.TabIndex = 2;
            EndToMenuButton.Text = "Menu";
            EndToMenuButton.UseVisualStyleBackColor = false;
            EndToMenuButton.Click += EndToMenuButton_Click;
            // 
            // EndLevelLabel
            // 
            EndLevelLabel.AutoSize = true;
            EndLevelLabel.BackColor = Color.Gray;
            EndLevelLabel.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EndLevelLabel.ForeColor = Color.Plum;
            EndLevelLabel.Location = new Point(198, 350);
            EndLevelLabel.Name = "EndLevelLabel";
            EndLevelLabel.Size = new Size(115, 43);
            EndLevelLabel.TabIndex = 3;
            EndLevelLabel.Text = "Level";
            // 
            // EndScreen
            // 
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(515, 593);
            Controls.Add(EndLevelLabel);
            Controls.Add(EndToMenuButton);
            Controls.Add(AgainButton);
            Controls.Add(EndPictureBox);
            Name = "EndScreen";
            FormClosing += EndScreen_FormClosing;
            ((System.ComponentModel.ISupportInitialize)EndPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox EndPictureBox;
        private RoundButton AgainButton;
        private RoundButton EndToMenuButton;
        private RoundedLabel EndLevelLabel;
    }
}
