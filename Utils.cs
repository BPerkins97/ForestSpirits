using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ForestSpirits.Frontend
{
	internal class FileUtils
	{
		private static string RESOURCES_PATH = Application.StartupPath + @"\static\";

		public static Image loadImage(string imageName)
		{
			string path = RESOURCES_PATH + imageName;
			return Image.FromFile(path);
		}
	}

	internal class MathUtils
	{
		public static float convertPixelToPoint(float pixel)
		{
			return pixel * 96 / 72;
		}
	}
}