using System;

namespace ForestSpirits.Business
{
	internal class StadtManager
	{
		public float bucked;
		private double wachstumsrate;
		private int tiles = 1;

		public bool blub()
		{
			wachstumsrate = Math.Pow(1.1, tiles);
			bucked = bucked + tiles * (float)wachstumsrate;
			Console.WriteLine(bucked);
			if (bucked >= 20)
			{
				tiles = tiles + 1;
				bucked = 0;
				return true;
			}
			return false;
		}
	}
}