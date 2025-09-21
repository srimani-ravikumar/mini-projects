using TicTacToe.Core;
using Xunit;

namespace TicTacToe.Tests
{
    public class BoardTests
    {
        [Fact]
        public void Board_InitiallyEmpty()
        {
            Board board = new Board();
            foreach (var cell in board.Cells)
            {
                Assert.Equal(' ', cell);
            }
        }

        [Fact]
        public void MakeMove_ValidPosition_UpdatesCell()
        {
            Board board = new Board();
            bool result = board.MakeMove(0, 'X');

            Assert.True(result);
            Assert.Equal('X', board.Cells[0]);
        }

        [Fact]
        public void MakeMove_InvalidPosition_ReturnsFalse()
        {
            Board board = new Board();
            board.MakeMove(0, 'X');

            bool result = board.MakeMove(0, 'O'); // Already occupied

            Assert.False(result);
            Assert.Equal('X', board.Cells[0]);
        }

        [Fact]
        public void CheckWin_Horizontal_ReturnsTrue()
        {
            Board board = new Board();
            board.MakeMove(0, 'X');
            board.MakeMove(1, 'X');
            board.MakeMove(2, 'X');

            bool win = board.CheckWin('X');
            Assert.True(win);
        }

        [Fact]
        public void CheckTie_FullBoard_ReturnsTrue()
        {
            Board board = new Board();
            char[] moves = { 'X', 'O', 'X', 'X', 'O', 'O', 'O', 'X', 'X' };
            for (int i = 0; i < moves.Length; i++)
                board.MakeMove(i, moves[i]);

            Assert.True(board.IsTie());
        }
    }
}
