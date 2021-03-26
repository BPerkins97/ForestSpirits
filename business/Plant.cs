using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSpirits.Business
{
    public class Plant
    {
        internal bool isSeedling()
        {
            return false;
        }
    }

    public class Seedling : Plant
	{
        new internal bool isSeedling()
        {
            return true;
        }
	}
}