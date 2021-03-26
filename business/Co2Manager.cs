using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSpirits.Business
{
	public class Co2Manager
	{
		public readonly int co2;

		public Co2Manager(int co2)
		{
			this.co2 = co2;
		}

		public Co2Manager withCo2(int co2)
        {
			return new Co2Manager(co2);
        }
	}
}
