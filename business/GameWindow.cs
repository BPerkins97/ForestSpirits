using ForestSpirits.Business;
using System;

namespace ForestSpirits.Business
{
	public interface GameWindow
	{
		void showGameState(GameState gameState);
	}

	public class GameState
	{
		public readonly string time = "00:00:00";
		public readonly int co2 = 0;
		public readonly bool isSunCollectable = false;
		public readonly bool isWaterCollectable = false;
		public bool isDisasterComing = false;
		public Disaster currentDisaster;
		public readonly Inventar inventar = new Inventar();
		public readonly Field[,] fields = new Field[0, 0];

		public GameState()
		{
			time = "";
			co2 = 0;
			isSunCollectable = false;
			isWaterCollectable = false;
			inventar = new Inventar();
			fields = new Field[0, 0];
		}

		public GameState(string time, int co2, bool isSunCollectable, bool isWaterCollectable, Inventar inventar, Field[,] fields, Disaster disaster, bool isDisasterComing)
		{
			this.time = time;
			this.co2 = co2;
			this.isSunCollectable = isSunCollectable;
			this.isWaterCollectable = isWaterCollectable;
			this.inventar = inventar;
			this.fields = fields;
			currentDisaster = disaster;
			this.isDisasterComing = isDisasterComing;
		}

		internal GameState withWater(bool isWaterCollectable)
		{
			return new GameState(time, co2, isSunCollectable, isWaterCollectable, inventar, fields, currentDisaster, isDisasterComing);
		}

		public static GameState createGameStateFromConfig(GameConfiguration config)
		{
			Field[,] fields = new Field[config.fieldRows, config.fieldColumns];
			for (int i = 0; i < config.fieldRows; i++)
			{
				for (int j = 0; j < config.fieldColumns; j++)
				{
					fields[i, j] = new Field();
					if (i == config.cityStart.row && j == config.cityStart.column)
					{
						fields[i, j] = fields[i, j].withType(FieldType.CITY);
					}
				}
			}

			return new GameState("00:00:00", config.co2StartValue, false, false, new Inventar(), fields, new Disaster(), false);
		}

		public GameState withSun(bool isSunCollectable)
		{
			return new GameState(time, co2, isSunCollectable, isWaterCollectable, inventar, fields, currentDisaster, isDisasterComing);
		}

		internal GameState withCo2(int co2)
		{
			return new GameState(time, co2, isSunCollectable, isWaterCollectable, inventar, fields, currentDisaster, isDisasterComing);
		}

		internal GameState withInventar(Inventar inventar)
		{
			return new GameState(time, co2, isSunCollectable, isWaterCollectable, inventar, fields, currentDisaster, isDisasterComing);
		}

		internal GameState withFields(Field[,] fields)
		{
			Field[,] temp = new Field[fields.GetLength(0), fields.GetLength(1)];
			Array.Copy(fields, temp, fields.GetLength(0) * fields.GetLength(1));
			return new GameState(time, co2, isSunCollectable, isWaterCollectable, inventar, fields, currentDisaster, isDisasterComing);
		}

		internal GameState withTime(string time)
		{
			return new GameState(time, co2, isSunCollectable, isWaterCollectable, inventar, fields, currentDisaster, isDisasterComing);
		}

		internal GameState withDisaster(Disaster disaster, bool isDisasterComing)
		{
			return new GameState(time, co2, isSunCollectable, isWaterCollectable, inventar, fields, disaster, isDisasterComing);
		}
	}
}