using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSpirits.business
{
	public class Inventar
	{
		public readonly int sun;
		public readonly int water;
		public readonly int seedlings;
		public readonly int mushrooms;

		public Inventar()
		{
			sun = 0;
			water = 0;
			seedlings = 3;
			mushrooms = 0;
		}

		public Inventar(int sun, int wasser, int setzlinge, int pilze)
		{
			this.sun = sun;
			this.water = wasser;
			this.seedlings = setzlinge;
			this.mushrooms = pilze;
		}

		public Inventar withSun(int sun)
		{
			return new Inventar(sun, water, seedlings, mushrooms);
		}

		public Inventar withWater(int water)
		{
			return new Inventar(sun, water, seedlings, mushrooms);
		}

		public Inventar withSeedlings(int seedlings)
		{
			return new Inventar(sun, water, seedlings, mushrooms);
		}

		public Inventar withMushrooms(int mushrooms)
		{
			return new Inventar(sun, water, seedlings, mushrooms);
		}
	}
}
