using System;

namespace TicTacToePlayer
{
    public class RandomPlayer : IPlayer
    {
        private static readonly Random _random = new Random();

        public string[] MakePlay(BoardState state)
        {
            var newState = (string[]) state.Board.Clone();

            while(true)
            {
                var index = _random.Next() % 9;
                if (state.Board[index] != "-") continue;
                newState[index] = state.NextPlayer;
                break;
            }

            return newState;
        }
    }
}