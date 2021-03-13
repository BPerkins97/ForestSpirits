using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Frontend.business
{
    class GameEngine
    {
        private GameWindow frontend;
        private int co2 = 5000;

        public GameEngine(GameWindow frontend)
        {
            this.frontend = frontend;
        }

        public async void start()
        {
            while (true)
            {
                GameState gameState = update();
                frontend.showGameState(gameState);
                await Task.Delay(1000);
            }
        }

        private GameState update()
        {
            GameState gameState = new GameState();
            gameState.time = DateTime.Now.ToString();
            gameState.co2 = this.co2;
            return gameState;
        }
    }
}
