using System.Drawing;
using System.Windows.Forms;

namespace Frontend
{
    public partial class ForestSpirits : Form
    {
        private const int BOARD_WIDTH = 3;
        private const int BOARD_HEIGHT = 4;

        private FieldMapper fieldMapper;

        public ForestSpirits()
        {
            InitializeComponent();
        }

        public void zeigeSpielesammlungAn()
        {
            Spielesammlung liste = getSpielesammlungen()
        }

        public Spielesammlung GetSpielesammlung()
        {
            return Spielesammlung();
        }

        private void drawBoard()
        {
            Graphics graphics = this.CreateGraphics();
            Image image = Image.FromFile("D:\\Repository\\ForestSpirits\\frontend\\static\\feld_mit_rand.png");

            float fieldWidth = convertPixelToPoint(image.Width);
            float fieldHeight = convertPixelToPoint(image.Height);

            fieldMapper = new FieldMapper(BOARD_HEIGHT, BOARD_WIDTH, fieldWidth, fieldHeight);
            float heightDiff = (float)(fieldHeight * 0.75);

            for (float y = 0; y < BOARD_HEIGHT / 2.0; y++) // This float: BOARD_HEIGHT / 2.0 is on purpose!
            {
                for (float x = 0; x < BOARD_WIDTH; x++)
                {
                    graphics.DrawImage(image, x * fieldWidth, y * 2 * heightDiff);
                }
            }
            for (float y = 0; y < BOARD_HEIGHT / 2; y++)
            {
                for (float x = 0; x < BOARD_WIDTH; x++)
                {
                     graphics.DrawImage(image, x * fieldWidth + fieldWidth / 2, y * 2 * heightDiff + heightDiff);
                }
            }
        }

        private void draw(object sender, PaintEventArgs e)
        {
            drawBoard();
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

        private void onClick(object sender, MouseEventArgs e)
        {
            PointF point = new PointF(e.X, e.Y);
            Coordinate coordinate = fieldMapper.pointToCoordinate(point);
        }
    }
}
