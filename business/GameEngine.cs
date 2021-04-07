using ForestSpirits.Business;
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
		private GameConfiguration config;
		private int prevTreeCount;
		private int updateTreeCount;
		private int co2Reduction = 100;
		private readonly int co2High;
		private readonly int co2Low;

		public GameEngine(GameWindow frontend)
		{
			config = new GameConfiguration();
			inventar = new Inventar();
			this.frontend = frontend;
			gameState = GameState.createGameStateFromConfig(config);
			random = new Random();
			fields = gameState.fields;
			co2High = config.co2High;
			co2Low = config.co2Low;
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
			if (inventar.seedlings > 0 && fields[location.row, location.column].type == FieldType.HIGH)
			{
				inventar = inventar.withSeedlings(inventar.seedlings - 1);
				fields[location.row, location.column] = fields[location.row, location.column]
					.withPlant(new Plant())
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
			FieldType type = fields[coord.row, coord.column].type;
			if (sun > 0 && water > 0 && (type == FieldType.NORMAL || type == FieldType.MEDIUM))
			{
				fields[coord.row, coord.column] = fields[coord.row, coord.column]
					.withSunStorage(sun - 1)
					.withWaterStorage(water - 1)
					.withType(nextLevel(type));
			}
		}

		private FieldType nextLevel(FieldType type)
		{
			switch (type)
			{
				case FieldType.NORMAL:
					return FieldType.MEDIUM;

				case FieldType.MEDIUM:
					return FieldType.HIGH;

				default:
					return FieldType.NORMAL;
			}
		}

		private void update()
		{
			// For local use
			Disaster disaster = gameState.currentDisaster;
			if (DateTime.Now >= disaster.triggerTime && gameState.isDisasterComing)
			{
				disaster.wasTriggered = true;
				gameState.isDisasterComing = false;
			}

			// Felder durchgehen
			for (int i = 0; i < fields.GetLength(0); i++)
			{
				for (int j = 0; j < fields.GetLength(1); j++)
				{
					Field field = fields[i, j];
					FieldType type = field.type;
					bool hasPlant = type == FieldType.SEEDLING || type == FieldType.TREE;
					bool isNature = type != FieldType.CITY;

					// Bepflanzte Felder
					if (hasPlant)
					{
						Plant plant = fields[i, j].plant;
						if (plant.sunStorage < config.resourceMax)
						{
							int amount = plant.sunStorage + config.resourceAdmissionRate;
							amount = Math.Min(config.resourceMax, amount);
							plant = plant
								.withSun(amount);
						}
						if (plant.waterStorage < config.resourceMax)
						{
							int amount = plant.waterStorage + config.resourceAdmissionRate;
							amount = Math.Min(config.resourceMax, amount);
							plant = plant
								.withWater(amount);
						}
						if (plant.waterStorage == config.resourceMax && plant.sunStorage == config.resourceMax && plant.progress < config.resourceMax)
						{
							int amount = plant.progress + config.resourceAdmissionRate;
							amount = Math.Min(config.resourceMax, amount);
							plant = plant.withProgress(amount);
						}
						if (type == FieldType.SEEDLING && plant.progress == config.resourceMax)
						{
							plant = new Plant();
							type = FieldType.TREE;
							updateTreeCount += 1;
						}

						if (plant.progress == config.resourceMax)
						{
							inventar = inventar.withSeedlings(inventar.seedlings + 1);
							plant.progress = 0;
						}

						if (prevTreeCount != updateTreeCount)
						{
							prevTreeCount = updateTreeCount;
							gameState.co2 -= co2Reduction;
						}

						if (disaster.wasTriggered)
						{
							field = field.withPlant(disaster.damagePlant(field.plant));
						}

						fields[i, j] = field
							.withPlant(plant)
							.withType(type);
					}

					// Unbepflanzte Felder
					if (!hasPlant && isNature)
					{
						if (disaster.wasTriggered)
						{
							field = disaster.damageField(field);
						}

						fields[i, j] = field;
					}
				}
			}

			if (gameState.co2 >= co2High && !gameState.isDisasterComing)
			{
				disaster = new Disaster(DisasterType.HEATWAVE, DisasterIntensity.HIGH);
				gameState.isDisasterComing = true;
			}

			if (gameState.co2 >= co2Low && !gameState.isDisasterComing)
			{
				disaster = new Disaster(DisasterType.HEATWAVE, DisasterIntensity.LOW);
				gameState.isDisasterComing = true;
			}

			if (gameState.isDisasterComing && disaster.wasTriggered)
			{
				gameState.isDisasterComing = false;
				disaster = new Disaster();
			}

			gameState = gameState
				.withTime(DateTime.Now.ToString())
				.withCo2(gameState.co2)
				.withSun(gameState.isSunCollectable || random.NextDouble() < 0.3)
				.withWater(gameState.isWaterCollectable || random.NextDouble() < 0.3)
				.withFields(fields)
				.withInventar(inventar)
				.withDisaster(disaster, gameState.isDisasterComing);
			Console.WriteLine("debug");
		}
	}
}