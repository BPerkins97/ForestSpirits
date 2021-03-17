﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
		private Co2Manager co2Manager = new Co2Manager();
		//private int co2 = 5000;

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

		public void setzlingPflanzen(BusinessCoordinate location)
		{
			//unfinished
            if (lastGameState.inventar.setzlinge > 0)
			{
				lastGameState.inventar.setzlinge--;
				Setzling newSetzling = new Setzling(location);
				lastGameState.pflanzenRegister.setzlinge.Add(newSetzling);
			}
		}

        public void fueternMitSonne(BusinessCoordinate location)
        {
            if (lastGameState.inventar.sonne > 0)
            {
                lastGameState.inventar.sonne--;
				Feld newFeld = new Feld(location);
				lastGameState.feldRegister.felder.Add(newFeld);
			}
        }

		public void fueternMitWasser(BusinessCoordinate location)
		{
			if (lastGameState.inventar.wasser > 0)
			{
				lastGameState.inventar.wasser--;
				Feld newFeld = new Feld(location);
				lastGameState.feldRegister.felder.Add(newFeld);
			}
		}

		private GameState update()
		{
			GameState gameState = new GameState();
			gameState.time = DateTime.Now.ToString();
			gameState.co2 = this.co2Manager.Co2Level;
			gameState.sonneZumSammeln = (lastGameState.sonneZumSammeln || random.NextDouble() < 0.1);
			gameState.wasserZumSammeln = (lastGameState.wasserZumSammeln || random.NextDouble() < 0.1);
			gameState.inventar = lastGameState.inventar;
			gameState.pflanzenRegister = lastGameState.pflanzenRegister;
			gameState.feldRegister = lastGameState.feldRegister;
			return gameState;
		}

	}
}
