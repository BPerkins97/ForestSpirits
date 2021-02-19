using System;
using System.Drawing;
using System.Windows.Forms;

namespace Frontend
{
    public partial class Form1 : Form
    {
        private const int BOARD_WIDTH = 20;
        private const int BOARD_HEIGHT = 10;

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

            for (float y = 0;y < BOARD_HEIGHT / 2;y++) {
                for (float x = 0; x < BOARD_WIDTH; x++)
                {
                    graphics.DrawImage(image, x * widthPixel, y * 2 * heightDiff);
                    graphics.DrawImage(image, x * widthPixel + widthPixel / 2, y * 2 * heightDiff + heightDiff);
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
