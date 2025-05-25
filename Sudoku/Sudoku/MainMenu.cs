namespace Sudoku
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            LevelGetter();
        }
        private void LevelGetter()
        {
            if (File.Exists("savedlevel.txt"))
            {
                LevelLabel.Text = $"Level {File.ReadAllText("savedlevel.txt")}";
            }
            else
            {
                Console.WriteLine("Файл savedlevel.txt не существует");
            }
        }
        private void StartGame(object sender, EventArgs e)
        {
            this.Hide();
            SudokuForm game = new SudokuForm();
            game.FormClosed += (s, args) => this.Show();
            game.Show();
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            GameHistory gamehistory = new GameHistory();
            gamehistory.Show();
        }
    }
}

