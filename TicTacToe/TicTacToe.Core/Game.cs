namespace TicTacToe.Core
{
    public class Game
    {
        private readonly IPlayer playerX;
        private readonly IPlayer playerO;
        private IPlayer currentPlayer;

        private bool gameRunning;

        public Board Board { get; private set; }

        public Game(IPlayer playerX, IPlayer playerO)
        {
            this.playerX = playerX;
            this.playerO = playerO;
            this.currentPlayer = playerX;

            // initialize board
            this.Board = new Board(); 
            this.gameRunning = true;
        }

        public void Start()
        {
            while (gameRunning)
            {
                BoardRenderer.Print(Board);
                int move = currentPlayer.GetMove(Board);
                Board.MakeMove(move, currentPlayer.Symbol);

                if (Board.CheckWin(currentPlayer.Symbol))
                {
                    BoardRenderer.Print(Board);
                    Console.WriteLine($"Player {currentPlayer.Symbol} wins!");
                    gameRunning = false;
                }
                else if (Board.IsTie())
                {
                    BoardRenderer.Print(Board);
                    Console.WriteLine("Match Tied!");
                    gameRunning = false;
                }
                else
                {
                    SwitchPlayer();
                }
            }
        }

        private void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == playerX) ? playerO : playerX;
        }
    }
}