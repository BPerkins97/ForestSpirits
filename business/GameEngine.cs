using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ForestSpirits.Business
{
	internal class GameEngine
	{
		private GameWindow frontend;
		private GameState lastGameState = new GameState();
		private Random random;
		private int co2 = 5000;

		public GameEngine(GameWindow frontend)
		{
			this.frontend = frontend;
			random = new Random();
		}

		public async void start()
		{
			while (true)
			{
				lastGameState = update();
				frontend.showGameState(lastGameState);
				await Task.Delay(1000 / 30);
			}
		}

		public void sammleSonne()
		{
			lastGameState.sonneZumSammeln = false;
			lastGameState.inventar.sonne++;
		}

		public void sammleWasser()
		{
			lastGameState.wasserZumSammeln = false;
			lastGameState.inventar.wasser++;
		}

		private GameState update()
		{
			GameState gameState = new GameState();
			gameState.time = DateTime.Now.ToString();
			gameState.co2 = this.co2;
			gameState.sonneZumSammeln = (lastGameState.sonneZumSammeln || random.NextDouble() < 0.1);
			gameState.wasserZumSammeln = (lastGameState.wasserZumSammeln || random.NextDouble() < 0.1);
			gameState.inventar = lastGameState.inventar;

			return gameState;
		}
	}
}