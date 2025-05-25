namespace Sudoku
{
    public class SudokuGenerator
    {
        private static Random rand = new Random();
        public int[,] Board { get; private set; }

        public SudokuGenerator()
        {
            Board = new int[9, 9];
            GenerateFullBoard();
            RemoveNumbersForPuzzle();
        }

        private void GenerateFullBoard()
        {
            Board = new int[9, 9];
            FillDiagonalBoxes();
            FillRemainingCells(0, 3);
        }

        private void FillDiagonalBoxes()
        {
            for (int i = 0; i < 9; i += 3)
                FillBox(i, i);
        }

        private void FillBox(int row, int col)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    int index = rand.Next(numbers.Count);
                    Board[row + i, col + j] = numbers[index];
                    numbers.RemoveAt(index);
                }
        }

        private bool FillRemainingCells(int row, int col)
        {
            // если столбец больше предела, переход к следующей строке
            if (col >= 9)
            {
                col = 0;
                row++; // переход к следующей строке
            }

            // Если достигнут конец всех строк, вернуть true так как заполнение завершено
            if (row >= 9) return true;

            // Если текущая клетка уже заполнена, пропустить её и идти дальше
            if (Board[row, col] != 0) return FillRemainingCells(row, col + 1);

            // Пробует все возможные числа от 1 до 9 для текущей клетки
            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(row, col, num)) // Проверка можно ли поставить число
                {
                    Board[row, col] = num;

                    // Рекурсивно пытается заполнить следующую клетку
                    if (FillRemainingCells(row, col + 1)) return true;

                    // Если не удалось заполнить, откатить изменения
                    Board[row, col] = 0;
                }
            }

            // Если ни одно число не подошло, вернуть false, чтобы откатить изменения
            return false;
        }

        private bool IsSafe(int row, int col, int num)
        {
            for (int x = 0; x < 9; x++)
                if (Board[row, x] == num || Board[x, col] == num) return false;

            int startRow = row - row % 3, startCol = col - col % 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (Board[i + startRow, j + startCol] == num) return false;

            return true;
        }

        private void RemoveNumbersForPuzzle()
        {
            int clues = 30; // Количество видимых чисел
            int removed = 81 - clues;

            while (removed > 0)
            {
                int row = rand.Next(9);
                int col = rand.Next(9);
                if (Board[row, col] != 0)
                {
                    Board[row, col] = 0;
                    removed--;
                }
            }
        }
    }
}
