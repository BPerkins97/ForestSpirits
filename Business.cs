using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSpirits.Business
{
	public class Co2Manager
	{
		private static int START_CO2 = 2999;
		public int Co2Level { get; set; }

		public Co2Manager(int startCo2 = 0)
		{
			this.Co2Level = START_CO2;
		}

		public string hello()
		{
			return "hellO";
		}
	}
}
