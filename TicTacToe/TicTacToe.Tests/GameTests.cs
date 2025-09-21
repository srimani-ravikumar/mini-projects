using TicTacToe.Core;

namespace TicTacToe.Tests
{
    public class GameTests
    {
        [Fact]
        public void Game_WinDetected()
        {
            HumanPlayer playerX = new HumanPlayer('X');
            HumanPlayer playerO = new HumanPlayer('O');

            Game game = new Game(playerX, playerO);

            // Manually simulate moves leading to X winning
            game.Board.MakeMove(0, 'X');
            game.Board.MakeMove(3, 'O');
            game.Board.MakeMove(1, 'X');
            game.Board.MakeMove(4, 'O');
            game.Board.MakeMove(2, 'X');

            Assert.True(game.Board.CheckWin('X'));
        }

        [Fact]
        public void Game_TieDetected()
        {
            HumanPlayer playerX = new HumanPlayer('X');
            HumanPlayer playerO = new HumanPlayer('O');

            Game game = new Game(playerX, playerO);

            char[] moves = { 'X', 'O', 'X', 'X', 'O', 'O', 'O', 'X', 'X' };
            for (int i = 0; i < moves.Length; i++)
            {
                game.Board.MakeMove(i, moves[i]);
            }

            Assert.True(game.Board.IsTie());
        }
    }
}