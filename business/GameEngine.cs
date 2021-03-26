using ForestSpirits.business;
using Frontend.business;
using System;
using System.Threading.Tasks;

namespace ForestSpirits.Business
{
	internal class GameEngine
	{
		private GameWindow frontend;
		private GameState gameState;
		private Inventar inventar;
		private Field[,] fields;
		private Random random;
		private Co2Manager co2Manager;
		private GameConfiguration config;

		public GameEngine(GameWindow frontend)
		{
			config = new GameConfiguration();
			inventar = new Inventar();
			this.frontend = frontend;
			gameState = GameState.createGameStateFromConfig(config);
			co2Manager = new Co2Manager(config.co2StartValue);
			random = new Random();
			fields = gameState.fields;
		}

		public async void start()
		{
			while (true)
			{
				update();
				frontend.showGameState(gameState);
				await Task.Delay(1000 / 2);
			}
		}

		public void sammleSonne()
		{
			gameState = gameState.withSun(false);
			inventar = inventar.withSun(inventar.sun + 1);
		}

		public void sammleWasser()
		{
			gameState = gameState.withWater(false);
			inventar = inventar.withWater(inventar.water + 1);
		}

		public void setzlingPflanzen(Coordinate location)
		{
            if (inventar.seedlings > 0 && gameState.fields[location.row, location.column].plant != null)
			{
				inventar = inventar.withSeedlings(inventar.seedlings - 1);
				fields[location.row, location.column] = fields[location.row, location.column]
					.withPlant(new Seedling())
					.withType(FieldType.SEEDLING);

			}
		}

        public void feedSun(Coordinate location)
        {
            if (inventar.sun > 0)
            {
				fields[location.row, location.column] = fields[location.row, location.column]
					.withSunStorage(fields[location.row, location.column].sunStorage + 1);
				inventar = inventar.withSun(inventar.sun - 1);
				updateFieldType(location);
			}
        }

		public void feedWater(Coordinate location)
		{
			if (inventar.water > 0)
			{
				fields[location.row, location.column] = fields[location.row, location.column]
					.withWaterStorage(fields[location.row, location.column].waterStorage + 1);
				inventar = inventar.withWater(inventar.water - 1);
				updateFieldType(location);
			}
		}

        private void updateFieldType(Coordinate coord)
        {
			int sun = fields[coord.row, coord.column].sunStorage;
			int water = fields[coord.row, coord.column].waterStorage;
			if (sun > 0 && water > 0)
            {
				fields[coord.row, coord.column] = fields[coord.row, coord.column]
					.withSunStorage(sun - 1)
					.withWaterStorage(water - 1)
					.withType(FieldLevelFactory.nextLevel(fields[coord.row, coord.column].type));
            }
        }

        private void update()
		{
			gameState = gameState
				.withTime(DateTime.Now.ToString())
				.withCo2(co2Manager.co2)
				.withSun(gameState.isSunCollectable || random.NextDouble() < 0.3)
				.withWater(gameState.isWaterCollectable || random.NextDouble() < 0.3)
				.withFields(fields)
				.withInventar(inventar);
		}

	}
}
