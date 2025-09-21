namespace TicTacToe.Core
{
    public class HumanPlayer : IPlayer
    {
        public char Symbol { get; }

        public HumanPlayer(char symbol)
        {
            Symbol = symbol;
        }

        public int GetMove(Board board)
        {
            int move;
            while (true)
            {
                Console.Write($"Player {Symbol}, enter a position (1-9): ");
                if (int.TryParse(Console.ReadLine(), out move) &&
                    move >= 1 && move <= 9 &&
                    board.Cells[move - 1] == ' ')
                {
                    return move - 1;
                }
                Console.WriteLine("Invalid move. Try again.");
            }
        }
    }
}