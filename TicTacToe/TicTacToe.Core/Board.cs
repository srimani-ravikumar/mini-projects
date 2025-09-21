namespace TicTacToe.Core
{
    public class Board
    {
        private readonly char[] cells;

        public Board()
        {
            cells = Enumerable.Repeat(' ', 9).ToArray();
        }

        public char[] Cells => cells;

        public bool MakeMove(int position, char symbol)
        {
            if (position >= 0 && position < 9 && cells[position] == ' ')
            {
                cells[position] = symbol;
                return true;
            }
            return false;
        }

        public bool CheckWin(char symbol)
        {
            int[,] winningCombos =
            {
                {0,1,2}, {3,4,5}, {6,7,8}, // Rows
                {0,3,6}, {1,4,7}, {2,5,8}, // Columns
                {0,4,8}, {2,4,6}           // Diagonals
            };

            for (int i = 0; i < winningCombos.GetLength(0); i++)
            {
                if (cells[winningCombos[i, 0]] == symbol &&
                    cells[winningCombos[i, 1]] == symbol &&
                    cells[winningCombos[i, 2]] == symbol)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsTie()
        {
            return cells.All(c => c != ' ');
        }
    }
}