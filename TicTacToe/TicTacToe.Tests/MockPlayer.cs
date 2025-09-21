using TicTacToe.Core;

public class MockPlayer : IPlayer
{
    private Queue<int> moves;
    public char Symbol { get; }

    public MockPlayer(char symbol, IEnumerable<int> movesSequence)
    {
        Symbol = symbol;
        moves = new Queue<int>(movesSequence);
    }

    public int GetMove(Board board) => moves.Dequeue();
}