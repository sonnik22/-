using static System.Net.Mime.MediaTypeNames;

namespace Sudoku
{
    public partial class EndScreen : Form
    {
        public int currentlevel;
        private SudokuForm previousGameForm;
        public EndScreen(SudokuForm game)
        {
            InitializeComponent();
            previousGameForm = game;
            ReadLevel();
        }
        private void ReadLevel()
        {
            if (File.Exists("savedlevel.txt"))
            {
                if (int.TryParse(File.ReadAllText("savedlevel.txt"), out int level))
                {
                    currentlevel = level;
                    EndLevelLabel.Text = $"Level {currentlevel}";
                }
                else
                {
                    Console.WriteLine("Прочитанный уровень из файла не является числом.");
                    currentlevel = 1;
                }
            }
            else
            {
                Console.WriteLine("Файл savedlevel.txt не существует.");
            }
        }
        public void SaveGameResult(string result)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string line = $"{currentlevel}|{result}|{timestamp}";

            using (StreamWriter writer = new StreamWriter("gamehistory.txt", append: true))
            {
                writer.WriteLine(line);
            }
        }
        private void SetLevel()
        {
            if (File.Exists("savedlevel.txt"))
            {
                int level = int.Parse(File.ReadAllText("savedlevel.txt")) + 1;
                File.WriteAllText("savedlevel.txt", level.ToString());
            }
        }
        public void ResultLogic(int result)
        {
            EndPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            if (result == 1)
            {
                EndPictureBox.Image = System.Drawing.Image.FromFile(@"win.png");
                SetLevel();
            }
            else
            {
                EndPictureBox.Image = System.Drawing.Image.FromFile(@"lose.png");
            }
        }

        private void AgainButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousGameForm.CleanerUserInput();
            previousGameForm.Show();
        }

        private void EndToMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.FormClosed += (s, args) => this.Show();
            menu.Show();
        }

        private void EndScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
