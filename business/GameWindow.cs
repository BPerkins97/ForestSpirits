namespace Frontend.business
{
    interface GameWindow
    {
        void showGameState(GameState gameState);
    }

    public class GameState
    {
        public string time;
        public int co2;
    }
}
