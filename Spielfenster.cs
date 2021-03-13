using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Threading;
using ForestSpirits.Business;

namespace ForestSpirits.Frontend
{
	public partial class Spielfenster : Form
	{
		private Board board;
		private Stopwatch gameTimer;
		private string gameTime;
		private DispatcherTimer dispatcherTimer;

		public Spielfenster()
		{
			InitializeComponent();

			this.board = new Board(3, 3);

			this.initTimer();

			Co2Manager meinCo2Manager = new Co2Manager();
			setCo2Label(Convert.ToString(meinCo2Manager.Co2Level));
		}

		private void initTimer()
		{
			this.gameTimer = new Stopwatch();
			this.gameTime = string.Empty;
			this.dispatcherTimer = new DispatcherTimer();
			this.dispatcherTimer.Tick += new EventHandler(update);
			this.dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
			this.dispatcherTimer.Start();
			this.gameTimer.Start();
		}

		private void update(object sender, EventArgs e)
		{
			TimeSpan span = gameTimer.Elapsed;
			this.gameTime = string.Format("{0:00}:{1:00}:{2:00}",
			span.Minutes, span.Seconds, span.Milliseconds / 10);
			this.setSpielzeitLabel(gameTime);
		}

		public void setCo2Label(string newText)
		{
			this.lCo2LevelWert.Text = newText;
		}

		public void setSpielzeitLabel(string newText)
		{
			this.lSpielzeitWert.Text = newText;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void sonne_Click(object sender, EventArgs e)
        {

        }
    }
}