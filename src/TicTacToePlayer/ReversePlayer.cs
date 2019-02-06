namespace TicTacToePlayer
{
    public class ReversePlayer: IPlayer
    {
        public string[] MakePlay(BoardState state)
        {
            var newState = (string[]) state.Board.Clone();
            for (var i = state.Board.Length - 1; i >= 0; i--)
            {
                if (state.Board[i] == "-")
                {
                    newState[i] = state.NextPlayer;
                    break;
                }
            }
            return newState;
        }
    }
}