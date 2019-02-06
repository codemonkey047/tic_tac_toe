namespace TicTacToePlayer
{
    public class PlayerFactory
    {
        public IPlayer GetPlayer(string playerType)
        {
            switch (playerType)
            {
                case "optimized-random":
                    return new OptimizedPlayer(new RandomPlayer());
                case "reverse":
                    return new ReversePlayer();
                default:
                    return new RandomPlayer();
            }
        }
    }
}