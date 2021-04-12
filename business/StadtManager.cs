using System;

namespace ForestSpirits.Business
{
	internal class StadtManager
	{
		private GameConfiguration config;
		public StadtManager ()
        {
			config = new GameConfiguration();
		}
		public bool wachstum()
		{
			config.wachstumsrate = Math.Pow(1, config.tiles);
			config.bucket = config.bucket + config.tiles * config.wachstumsrate;
			if (config.bucket >= config.bucketFull)
			{
				config.tiles = config.tiles + config.addToTiles;
				config.bucket = 0;
				return true;
			}
			//Console.WriteLine(config.bucket);
			return false;
		}
	}
}