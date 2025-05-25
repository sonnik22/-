namespace Sudoku
{
    public partial class SudokuForm
    {
        private RoundButton ResetButton;
        private RoundButton DrawButton;
        private RoundButton CheckButton;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SudokuForm));
            ResetButton = new RoundButton();
            DrawButton = new RoundButton();
            CheckButton = new RoundButton();
            RegenerateButton = new RoundButton();
            SelectCellWarning = new RoundedLabel();
            SuspendLayout();
            // 
            // ResetButton
            // 
            ResetButton.BackColor = Color.Gray;
            ResetButton.Image = (Image)resources.GetObject("ResetButton.Image");
            ResetButton.Location = new Point(86, 506);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(80, 63);
            ResetButton.TabIndex = 0;
            ResetButton.UseVisualStyleBackColor = false;
            ResetButton.Click += ResetButton_Click;
            // 
            // DrawButton
            // 
            DrawButton.BackColor = Color.Gray;
            DrawButton.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DrawButton.ForeColor = Color.Plum;
            DrawButton.Location = new Point(187, 505);
            DrawButton.Name = "DrawButton";
            DrawButton.Size = new Size(156, 64);
            DrawButton.TabIndex = 1;
            DrawButton.Text = "Draw";
            DrawButton.UseVisualStyleBackColor = false;
            DrawButton.Click += DrawButton_Click;
            // 
            // CheckButton
            // 
            CheckButton.BackColor = Color.Gray;
            CheckButton.Image = Properties.Resources.check;
            CheckButton.Location = new Point(364, 505);
            CheckButton.Name = "CheckButton";
            CheckButton.Size = new Size(77, 64);
            CheckButton.TabIndex = 2;
            CheckButton.UseVisualStyleBackColor = false;
            CheckButton.Click += CheckButton_Click;
            // 
            // RegenerateButton
            // 
            RegenerateButton.BackColor = Color.Gray;
            RegenerateButton.Image = (Image)resources.GetObject("RegenerateButton.Image");
            RegenerateButton.Location = new Point(12, 530);
            RegenerateButton.Name = "RegenerateButton";
            RegenerateButton.Size = new Size(59, 51);
            RegenerateButton.TabIndex = 3;
            RegenerateButton.UseVisualStyleBackColor = false;
            RegenerateButton.Click += RegenerateButton_Click;
            // 
            // SelectCellWarning
            // 
            SelectCellWarning.AutoSize = true;
            SelectCellWarning.BackColor = Color.Gray;
            SelectCellWarning.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SelectCellWarning.ForeColor = Color.Brown;
            SelectCellWarning.Location = new Point(154, 35);
            SelectCellWarning.Name = "SelectCellWarning";
            SelectCellWarning.Size = new Size(266, 46);
            SelectCellWarning.TabIndex = 4;
            SelectCellWarning.Text = "Select a cell";
            SelectCellWarning.Visible = false;
            // 
            // SudokuForm
            // 
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(515, 593);
            Controls.Add(SelectCellWarning);
            Controls.Add(RegenerateButton);
            Controls.Add(CheckButton);
            Controls.Add(DrawButton);
            Controls.Add(ResetButton);
            MaximizeBox = false;
            Name = "SudokuForm";
            Text = "Sudoku";
            ResumeLayout(false);
            PerformLayout();
        }

        private RoundButton RegenerateButton;
        private RoundedLabel SelectCellWarning;
    }
}
