using TicTacToe.Core;

bool playAgain = true;

while (playAgain)
{
    Console.WriteLine("We are getting into TicTacToe Game!");

    // Create a new game instance each time
    var game = new Game(new HumanPlayer('X'), new HumanPlayer('O'));
    game.Start();

    // Ask user if they want to play again
    Console.Write("Do you want to play again? (y/n): ");
    string? input = Console.ReadLine()?.Trim().ToLower();
    playAgain = (input == "y" || input == "yes");

    // clears screen for the next game
    Console.Clear();
}
