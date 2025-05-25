namespace Sudoku
{
    public partial class SudokuForm : Form
    {
        private int[,] puzzle;
        private TextBox[,] cells = new TextBox[9, 9];
        private TextBox selectedTextBox = null;

        public SudokuForm()
        {
            SudokuGenerator generator = new SudokuGenerator();
            puzzle = generator.Board;
            InitializeComponent();
            GenerateSudokuField();
        }

        private void ReGenerate()
        {
            Controls.RemoveAll(c => c is TextBox);
            SudokuGenerator generator = new SudokuGenerator();
            puzzle = generator.Board;
            selectedTextBox = null;
            GenerateSudokuField();
        }

        private void GenerateSudokuField()
        {
            int cellSize = 50;
            int padding = 2;
            int blockPadding = 5;

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    int extraX = (col / 3) * blockPadding;
                    int extraY = (row / 3) * blockPadding;

                    TextBox cell = new TextBox
                    {
                        Width = cellSize,
                        Height = cellSize,
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 18, FontStyle.Bold),
                        MaxLength = 1,
                        Multiline = true,
                        Location = new Point(col * (cellSize + padding) 
                        + 20 + extraX,
                                             row * (cellSize + padding) 
                                             + 20 + extraY)
                    };

                    if (puzzle[row, col] != 0)
                    {
                        cell.Text = puzzle[row, col].ToString();
                        cell.ReadOnly = true;
                        cell.BackColor = Color.LightGray;
                    }
                    else
                    {
                        cell.KeyPress += OnlyDigit_KeyPress;
                    }

                    cells[row, col] = cell;
                    Controls.Add(cell);
                    cell.Enter += (s, e) => selectedTextBox = (TextBox)s;
                }
            }
        }

        private void OnlyDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешены только цифры или BackSpace
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar) 
                || e.KeyChar == '0'))
            {
                e.Handled = true;
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            CleanerUserInput();
        }
        public void CleanerUserInput()
        {
            selectedTextBox = null;
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (!cells[row, col].ReadOnly)
                    {
                        cells[row, col].Text = "";
                    }
                }
            }
        }
        private void CheckButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            EndScreen end = new EndScreen(this);
            end.FormClosed += (s, args) => this.Show();
            end.Show();
            if (IsSudokuSolved())
            {
                end.ResultLogic(1);
                end.SaveGameResult("win");
            }
            else
            {
                end.ResultLogic(0);
                end.SaveGameResult("lose");
            }
        }

        private bool IsSudokuSolved()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (!int.TryParse(cells[row, col].Text, out int value))
                        return false;
                    if (value < 1 || value > 9)
                        return false;

                    if (!IsValidPlacement(row, col, value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsValidPlacement(int row, int col, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != col && cells[row, i].Text == 
                    num.ToString()) return false;
                if (i != row && cells[i, col].Text == 
                    num.ToString()) return false;
            }
            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if ((startRow + i != row || startCol + j != col) && 
                        cells[startRow + i, startCol + j].Text 
                        == num.ToString())
                        return false;
            return true;
        }

        private void RegenerateButton_Click(object sender, EventArgs e)
        {
            ReGenerate();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            //Проверка был ли выбран TextBox для ввода
            if (selectedTextBox != null && !selectedTextBox.ReadOnly)
            {
                this.Enabled = false;
                DrawingForm drawingForm = new DrawingForm();
                drawingForm.Show();
                drawingForm.FormClosed += (s, args) =>
                {
                    selectedTextBox.Text = drawingForm.RecognizedNumber;
                    this.Enabled = true;
                };
                
            }
            else
            {
                SelectCellWarning.Visible = true;
                System.Windows.Forms.Timer timer 
                    = new System.Windows.Forms.Timer();
                timer.Interval = 3000;
                timer.Start();
                timer.Tick += new EventHandler(timer_Tick);
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            SelectCellWarning.Visible=false;
            ((System.Windows.Forms.Timer)sender).Stop();
            ((System.Windows.Forms.Timer)sender).Dispose();
        }
    }
    static class ControlExtensions
    {
        public static void RemoveAll(this Control.ControlCollection 
            controls, Predicate<Control> match)
        {
            foreach (Control control in controls.Cast<Control>().Where(c =>
            match(c)).ToList())
            {
                controls.Remove(control);
            }
        }
    }
}

