namespace Sudoku
{
    public partial class DrawingForm : Form
    {
        public string RecognizedNumber = "";
        private const int GridSizeX = 20;
        private const int GridSizeY = 28;
        private const int CellSize = 16;
        private Bitmap bitmap;
        private bool isDrawing = false;

        public DrawingForm()
        {
            InitializeComponent();
            InitializeCanvas();
        }

        private void InitializeCanvas()
        {
            bitmap = new Bitmap(GridSizeX * CellSize, GridSizeY * CellSize);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Gray);
                AddPattern(g);
            }
            pictureBox.Image = bitmap;
        }

        private void AddPattern(Graphics g)
        {
            Brush brush = Brushes.DimGray;
            //первый x, второй y, третий размер в длину по x, четвёртый размер в ширину по y
            // Верхняя перекладина
            g.FillRectangle(brush, 80, 32, 160, 16);

            // Средняя перекладина
            g.FillRectangle(brush, 80, 208, 160, 16);

            // Нижняя перекладина
            g.FillRectangle(brush, 80, 384, 160, 16);

            // Левая вертикаль верхнего кольца
            g.FillRectangle(brush, 64, 48, 16, 144);

            // Правая вертикаль верхнего кольца
            g.FillRectangle(brush, 240, 48, 16, 144);

            // Левая вертикаль нижнего кольца
            g.FillRectangle(brush, 64, 240, 16, 144);

            // Правая вертикаль нижнего кольца
            g.FillRectangle(brush, 240, 240, 16, 144);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                DrawAt(e.X, e.Y);
            }
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                DrawAt(e.X, e.Y);
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }
        private void DrawAt(int x, int y)
        {
            int col = x / CellSize;
            int row = y / CellSize;

            if (col >= 0 && col < GridSizeX && row >= 0 && row < GridSizeY)
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.FillRectangle(Brushes.DarkOrchid, col * CellSize, row * CellSize, CellSize, CellSize);
                }
                pictureBox.Invalidate(new Rectangle(col * CellSize, row * CellSize, CellSize, CellSize));
            }
        }

        private void DrawButtonReset_Click(object sender, EventArgs e)
        {
            InitializeCanvas();
        }

        private void RecognizeButton_Click(object sender, EventArgs e)
        {
            int recognizedPixels = 0;
            int[] NumberStructure = {0,0,0,0,0,0,0};
            Color darkOrchid = Color.DarkOrchid;
            //сначало y потом x 
            for (int y = 0; y < GridSizeY; y++)
            {
                for (int x = 0; x < GridSizeX; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x * CellSize + CellSize / 2, y * CellSize + CellSize / 2);
                    if ((pixelColor.R-153)<40 && (pixelColor.G - 50) < 40 && (pixelColor.B - 204) < 40)
                    {
                        //верняя палка
                        if (y == 2 && x > 4 && x < 15)
                            NumberStructure[0] += 1;
                        //верхняя левая палка
                        if (y > 2 && y < 12 && x == 4)
                            NumberStructure[1] += 1;
                        //верхняя правая палка
                        if (y > 2 && y < 12 && x == 15)
                            NumberStructure[2] += 1;
                        //по центру палка
                        if (y == 13 && x > 4 && x < 15)
                            NumberStructure[3] += 1;
                        //нижняя левая палка
                        if (y > 14 && y < 24 && x == 4)
                            NumberStructure[4] += 1;
                        //нижняя правая палка
                        if (y > 14 && y < 24 && x == 15)
                            NumberStructure[5] += 1;
                        //нижняя палка
                        if (y == 24 && x > 4 && x < 15)
                            NumberStructure[6] += 1;
                        recognizedPixels += 1;
                    }
                }
            }
            Console.WriteLine("Before");
            foreach (int num in NumberStructure)
                Console.WriteLine(num);
            for (int i = 0; i < 7; i++)
            {
                if (NumberStructure[i] > 1)
                    NumberStructure[i] = 1;
                else
                    NumberStructure[i] = 0;
            }
            switch(string.Join("", NumberStructure))
            {
                //1-верх
                //2-верх лево
                //3-верх право
                //4-центр
                //5-низ лево
                //6-низ право
                //7-низ
                //1
                case "1010010":
                    RecognizedNumber = "1";
                    break;
                case "0010010":
                    RecognizedNumber = "1";
                    break;
                //2
                case "1011101":
                    RecognizedNumber = "2";
                    break;
                //3
                case "1011011":
                    RecognizedNumber = "3";
                    break;
                //4
                case "0111010":
                    RecognizedNumber = "4";
                    break;
                //5
                case "1101011":
                    RecognizedNumber = "5";
                    break;
                //6
                case "1101111":
                    RecognizedNumber = "6";
                    break;
                //7
                case "1011010":
                    RecognizedNumber = "7";
                    break;
                //8
                case "1111111":
                    RecognizedNumber = "8";
                    break;
                //9
                case "1111011":
                    RecognizedNumber = "9";
                    break;

            }
            Console.WriteLine("After");
            foreach (int num in NumberStructure)
                Console.WriteLine(num);
            Console.WriteLine("Total");
            Console.WriteLine(recognizedPixels);
            Console.WriteLine("REcogNized");
            Console.WriteLine(RecognizedNumber);
            this.Close();
        }

    }
}
