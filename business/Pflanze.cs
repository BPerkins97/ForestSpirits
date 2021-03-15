using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSpirits.Business
{
	public class Pflanze
	{
		public BusinessCoordinate location;
		public readonly int id;
		public static Random idGenerator = new Random();

		public Pflanze(BusinessCoordinate location)
		{
			this.location = location;
			this.id = idGenerator.Next();
		}
	}

	public class Setzling : Pflanze
	{
		public Setzling(BusinessCoordinate location) : base(location)
		{
		}
	}

	// Kombinieren mit Frontend?
	public class BusinessCoordinate
	{
		public readonly int x;
		public readonly int y;

		public BusinessCoordinate(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
}