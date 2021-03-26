
using ForestSpirits.business;
using Frontend.business;
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
		public readonly int co2 = 5000;
		public readonly bool isSunCollectable = false;
		public readonly bool isWaterCollectable = false;
		public readonly Inventar inventar = new Inventar();
		public readonly Field[,] fields = new Field[5,5];
		public readonly int tiles = 0;

		public GameState()
        {
			time = "";
			co2 = 0;
			isSunCollectable = false;
			isWaterCollectable = false;
			inventar = new Inventar();
			fields = new Field[100, 100];
			tiles = 0;
        }

		public GameState(string time, int co2, bool isSunCollectable, bool isWaterCollectable, Inventar inventar, Field[,] fields, int tiles)
        {
			this.time = time;
			this.co2 = co2;
			this.isSunCollectable = isSunCollectable;
			this.isWaterCollectable = isWaterCollectable;
			this.inventar = inventar;
			this.fields = fields;
			this.tiles = tiles;
        }

        internal GameState withWater(bool isWaterCollectable)
        {
			return new GameState(time, co2, isSunCollectable, isWaterCollectable, inventar, fields, tiles);
		}

        public static GameState createGameStateFromConfig(GameConfiguration config)
        {
			Field[,] fields = new Field[config.fieldRows, config.fieldColumns];
			for (int i=0;i<config.fieldRows;i++)
            {
				for (int j=0;j<config.fieldColumns;j++)
                {
					fields[i, j] = new Field();
					Console.WriteLine(i + "," + j);
					if (i == config.cityStart.row && j == config.cityStart.column)
                    {
						Console.WriteLine("city");
						fields[i, j] = fields[i, j].withType(FieldType.CITY);
                    }
                }
            }

			return new GameState("00:00:00", config.co2StartValue, false, false, new Inventar(), fields, 0);
        }

		public GameState withSun(bool isSunCollectable)
        {
			return new GameState(time, co2, isSunCollectable, isWaterCollectable, inventar, fields, tiles);
        }

        internal GameState withCo2(int co2)
        {
			return new GameState(time, co2, isSunCollectable, isWaterCollectable, inventar, fields, tiles);
		}

        internal GameState withInventar(Inventar inventar)
        {
			return new GameState(time, co2, isSunCollectable, isWaterCollectable, inventar, fields, tiles);
		}

        internal GameState withFields(Field[,] fields)
        {
			Field[,] temp = new Field[fields.GetLength(0), fields.GetLength(1)];
			Array.Copy(fields, temp, fields.GetLength(0) * fields.GetLength(1));
			return new GameState(time, co2, isSunCollectable, isWaterCollectable, inventar, temp, tiles);
		}

        internal GameState withTime(string time)
        {
			return new GameState(time, co2, isSunCollectable, isWaterCollectable, inventar, fields, tiles);
		}
	}
}