namespace TicTacToe.Core
{
    internal static class BoardRenderer
    {
        public static void Print(Board board)
        {
            char[] b = board.Cells;
            Console.WriteLine();
            Console.WriteLine($" {b[0]} | {b[1]} | {b[2]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {b[3]} | {b[4]} | {b[5]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {b[6]} | {b[7]} | {b[8]} ");
            Console.WriteLine();
        }
    }
}