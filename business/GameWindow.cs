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
        public bool sonneZumSammeln;
        public bool wasserZumSammeln;
        public Inventar inventar;

        public GameState()
        {
            inventar = new Inventar();
        }
    }

    public class Inventar
    {
        public int sonne;
        public int wasser;
    }
}
