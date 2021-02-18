using System;
using System.Drawing;
using System.Windows.Forms;

namespace Frontend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Image image = Image.FromFile("D:\\Repository\\ForestSpirits\\frontend\\Frontend\\static\\feld_mit_rand.png");

            Rectangle screenSize = Screen.PrimaryScreen.Bounds;

            float widthPixel = convertPixelToPoint(image.Width);
            float heightPixel = convertPixelToPoint(image.Height);
            float heightDiff = (float)(heightPixel * 0.75);

            for (float y = 0;y < screenSize.Height;y += (float)(heightPixel * 1.5)) {
                for (float x = 0; x < screenSize.Width; x += widthPixel)
                {
                    graphics.DrawImage(image, x, y);
                }
            }
            for (float y = heightDiff; y < screenSize.Height; y += (float)(heightPixel * 1.5))
            {
                for (float x = (float)(widthPixel / 2.0); x < screenSize.Width; x += widthPixel)
                {
                    graphics.DrawImage(image, x - 1, y);
                }
            }




        }
        private float convertPixelToPoint(int pixel)
        {
            return pixel * 96 / 72;
        }


        private PointF[] drawHexagon(double x, double y, double width, double height)
        {
            return new PointF[]{
                new PointF((float)x,(float)y),
                new PointF((float)(x - 0.5 * width), (float)(y + 0.25F * height)),
                new PointF((float)(x - 0.5 * width), (float)(y + 0.75F * height)),
                new PointF((float)x, (float)(y + height)),
                new PointF((float)(x + 0.5 * width), (float)(y + 0.75 * height)),
                new PointF((float)(x + 0.5 * width), (float)(y + 0.25 * height)),      
                new PointF((float)x, (float)y),
            };
        }
    }
}
