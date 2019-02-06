using System.Diagnostics;

namespace TicTacToePlayer
{
    public class OptimizedPlayer : IPlayer
    {
        private readonly IPlayer _basePlayer;

        public OptimizedPlayer(IPlayer basePlayer)
        {
            _basePlayer = basePlayer;
        }

        public string[] MakePlay(BoardState state)
        {
            var newState = (string[])state.Board.Clone();
            var combinedString = string.Join("", state.Board);

            var selection = MakeOptimizedPlay(combinedString, state.NextPlayer);

            if (selection == -1)
            {
                newState = _basePlayer.MakePlay(state);
            }
            else
            {
                newState[selection] = state.NextPlayer;
            }

            return newState;
        }

        //012
        //345
        //678
        private int MakeOptimizedPlay(string state, string nextPlayer)
        {
            var otherPlayer = nextPlayer == "X" ? "O" : "X";

            // Check for a horizonal win
            if (CheckHorizontal(state, nextPlayer, out var makeOptimizedPlay)) return makeOptimizedPlay;

            // Check for a vertical win
            if (CheckVertical(state, nextPlayer, out makeOptimizedPlay)) return makeOptimizedPlay;

            // Check for a horizonal potential loss
            if (CheckHorizontal(state, otherPlayer, out makeOptimizedPlay)) return makeOptimizedPlay;

            // Check for a vertical potential loss
            if (CheckVertical(state, nextPlayer, out makeOptimizedPlay)) return makeOptimizedPlay;

            return -1;
        }

        private static bool CheckHorizontal(string state, string nextPlayer, out int makeOptimizedPlay)
        {
            makeOptimizedPlay = -1;
            for (var i = 0; i < 9; i += 3)
            {
                if (state[i] != state[i + 2] || state[i + 1] != '-' || state[i] != nextPlayer[0]) continue;
                {
                    makeOptimizedPlay = i + 1;
                    return true;
                }
            }
            return false;
        }

        private static bool CheckVertical(string state, string nextPlayer, out int makeOptimizedPlay)
        {
            makeOptimizedPlay = -1;
            return false;
        }
    }
} 
