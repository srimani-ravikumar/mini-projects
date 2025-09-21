namespace TicTacToe.Core
{
    public interface IPlayer
    {
        char Symbol { get; }
        int GetMove(Board board);
    }
}