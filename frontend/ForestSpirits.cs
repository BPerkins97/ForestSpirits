using System.Drawing;
using System.Windows.Forms;

namespace Frontend
{
    public partial class ForestSpirits : Form
    {
        private Board board;

        public ForestSpirits()
        {
            InitializeComponent();
            board = new Board(3, 3);
        }

        private void draw(object sender, PaintEventArgs e)
        {
            board.draw(this.CreateGraphics());
        }

        private float convertPixelToPoint(int pixel)
        {
            return pixel * 96 / 72;
        }

        private void onClick(object sender, MouseEventArgs e)
        {
            Coordinate coordinate = board.getCoordinates(e.X, e.Y);
            MessageBox.Show(coordinate.x + "|" + coordinate.y);
        }
    }
}
