namespace Sudoku
{
    public partial class GameHistory : Form
    {
        public GameHistory()
        {
            InitializeComponent();
            LoadGameHistory();
        }
        private void LoadGameHistory()
        {
            historyGridView.Columns.Clear();
            historyGridView.Rows.Clear();
            historyGridView.Columns.Add("Level", "Level");
            historyGridView.Columns.Add("Result", "Result");
            historyGridView.Columns.Add("Date", "Date");
            historyGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (File.Exists("gamehistory.txt"))
            {
                var lines = File.ReadAllLines("gamehistory.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        historyGridView.Rows.Add(parts[0], parts[1], parts[2]);
                    }
                }
            }
        }
    }
}
