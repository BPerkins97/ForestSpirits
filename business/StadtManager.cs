﻿using System;

namespace ForestSpirits.business
{
	internal class StadtManager
	{
		public float bucked;
		private double wachstumsrate;
		private int tiles;

		public void blub()
		{
			wachstumsrate = Math.Pow(1.1, tiles);
			bucked = bucked + tiles * (float)wachstumsrate;

			if (bucked == 2000)
			{
				tiles = tiles + 1;
				bucked = 0;
			};
		}
	}
}