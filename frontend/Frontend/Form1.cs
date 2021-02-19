using System;
using System.Drawing;
using System.Windows.Forms;

namespace Frontend
{
    public partial class Form1 : Form
    {
        private const int BOARD_WIDTH = 2;
        private const int BOARD_HEIGHT = 2;

        private Graphics graphics;
        private float fieldWidth;
        private float fieldHeight;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            Image image = Image.FromFile("D:\\Repository\\ForestSpirits\\frontend\\Frontend\\static\\feld_mit_rand.png");

            Rectangle screenSize = Screen.PrimaryScreen.Bounds;

            fieldWidth = convertPixelToPoint(image.Width);
            fieldHeight = convertPixelToPoint(image.Height);
            float heightDiff = (float)(fieldHeight * 0.75);

            for (float y = 0;y < BOARD_HEIGHT;y++) {
                for (float x = 0; x < BOARD_WIDTH; x++)
                {
                    graphics.DrawImage(image, x * fieldWidth, y * 2 * heightDiff);
                    graphics.DrawImage(image, x * fieldWidth + fieldWidth / 2, y * 2 * heightDiff + heightDiff);
                }
            }
            

            for (int i = 0; i < BOARD_HEIGHT; i++)
            {
                for (int j = 0; j < BOARD_WIDTH; j++)
                {
                    isSelected(j, i, 0, 0);
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

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            int x = -1;
            int y = -1;
            bool found = false;
            for (int i=0;i<BOARD_HEIGHT;i++)
            {
                for (int j=0;j<BOARD_WIDTH;j++)
                {
                    if (!found && isSelected(j,i, e.X, e.Y))
                    {
                        x = i;
                        y = j;
                        found = true;
                    }
                }
            }

            MessageBox.Show("" + e.X + "|" + e.Y + "\n" + x + "|" + y + "\n" + fieldWidth + "|" + fieldHeight);
        }

        private bool isSelected(int x, int y, float actualX, float actualY)
        {
            float xBase = y % 2 == 1 ? fieldWidth / 2 : 0;
            PointF lowerLeft = new PointF(xBase + x * fieldWidth, (float)((y + 1) * 0.75 * fieldHeight));
            PointF lower = new PointF(xBase + fieldWidth / 2 + x * fieldWidth, (float)(fieldHeight + y * 0.75 * fieldHeight));
            PointF lowerRight = new PointF(xBase + fieldWidth + x * fieldWidth, (float)((y + 1) * 0.75 * fieldHeight));

            float steigung = (lower.Y - lowerLeft.Y) / (lower.X - lowerLeft.X);
            float basis = steigung * lower.X * -1 + lower.Y;

            float shouldBeY = steigung * actualX + basis;
            if (actualY > shouldBeY)
            {
                return false;
            }

            steigung = -steigung;
            basis = steigung * lower.X * -1 + lower.Y;

            shouldBeY = steigung * actualX + basis;
            if (actualY > shouldBeY)
            {
                return false;
            }

            if (actualX > lowerRight.X)
            {
                return false;
            }
            return true;
        }
    }
}
