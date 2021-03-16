using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Threading;
using ForestSpirits.Business;
using System.Threading;

namespace ForestSpirits.Frontend
{
	public partial class Spielfenster : Form, GameWindow
	{
		private GameEngine game;
		private Board board;
		private Point sonneLocation;
		private Point wasserLocation;
		private int sonneWidth = 100;
		private int pflanzeWidth = 40;
		private GameState lastGameState;
		private Image sonneImg;
		private Image wasserImg;
		private Image setzlingImg;
		private bool setzlingReady = false;

		public Spielfenster()
		{
			InitializeComponent();
			game = new GameEngine(this);

			this.board = new Board(3, 4);
			lastGameState = new GameState();
			sonneImg = FileUtils.loadImage("sonne.png");
			sonneImg = FileUtils.resizeImage(sonneImg, sonneWidth, sonneWidth);
			wasserImg = FileUtils.loadImage("wasser.png");
			wasserImg = FileUtils.resizeImage(wasserImg, sonneWidth, sonneWidth);
			setzlingImg = FileUtils.loadImage("setzling.png");
			setzlingImg = FileUtils.resizeImage(setzlingImg, pflanzeWidth, pflanzeWidth);
		}

		public void showGameState(GameState gameState)
		{
			this.lSpielzeitWert.Text = gameState.time;
			this.lCo2LevelWert.Text = "" + gameState.co2;
			// weil das mir auf die Eier gegangen ist nach einer Weile xD könnt es auch gerne
			// sauberer umgestalten
			try
			{
				this.CreateGraphics();
			}
			catch
			{
				Environment.Exit(0); // 0 = Sucess
			}
			Graphics graphics = this.CreateGraphics();

			if (gameState.sonneZumSammeln)
			{
				if (!lastGameState.sonneZumSammeln)
				{
					sonneLocation = new Point(MathUtils.random.Next(0, (int)board.getSize().Width - sonneWidth), MathUtils.random.Next(0, (int)board.getSize().Height - sonneWidth));
				}
				graphics.DrawImage(sonneImg, sonneLocation);
			}

			if (gameState.wasserZumSammeln)
			{
				if (!lastGameState.wasserZumSammeln)
				{
					wasserLocation = new Point(MathUtils.random.Next(0, (int)board.getSize().Width - sonneWidth), MathUtils.random.Next(0, (int)board.getSize().Height - sonneWidth));
				}
				graphics.DrawImage(wasserImg, wasserLocation);
			}

			foreach (Setzling setzling in gameState.pflanzenRegister.setzlinge)
			{
				Point location = board.getPoint(new Coordinate(setzling.location.x, setzling.location.y));
				//Point location = new Point(setzling.location.x, setzling.location.y);
				graphics.DrawImage(setzlingImg, location);
				//graphics.DrawImage(setzlingImg, new Point(111 / 2, 111 / 2));
				Console.WriteLine("test");
			}

			// Inventar befüllen
			this.sonne.Text = "Sonne " + gameState.inventar.sonne;
			this.wasser.Text = "Wasser " + gameState.inventar.wasser;
			this.setzlinge.Text = "Setzlinge " + gameState.inventar.setzlinge;
			lastGameState = gameState;
		}

		private void onClick(object sender, MouseEventArgs e)
		{
			// last click debug
			lLastClickPixelsWert.Text = Convert.ToString(e.Location);
			Coordinate coordinate = board.getCoordinates(e.X, e.Y);
			lLastClickCoordinatesWert.Text = $"({coordinate.x}, {coordinate.y})";

			if (e.X > sonneLocation.X && e.X < sonneLocation.X + sonneWidth && e.Y > sonneLocation.Y && e.Y < sonneLocation.Y + sonneWidth)
			{
				game.sammleSonne();
				Graphics graphics = this.CreateGraphics();
				graphics.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height));
				board.draw(graphics);
				resetButtons();
			}
			if (e.X > wasserLocation.X && e.X < wasserLocation.X + sonneWidth && e.Y > wasserLocation.Y && e.Y < wasserLocation.Y + sonneWidth)
			{
				game.sammleWasser();
				Graphics graphics = this.CreateGraphics();
				graphics.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height));
				board.draw(graphics);
				resetButtons();
			}
			if (setzlingReady)
			{
				game.setzlingPflanzen(new BusinessCoordinate(coordinate.x, coordinate.y));
				resetButtons();
				//WIP
			}
			else
			{
			}
		}

		// wenn geclickt wird, sollen die Buttons nicht "aktiv" bleiben
		private void resetButtons()
		{
			this.setzlingReady = false;
		}

		private void start(object sender, EventArgs e)
		{
			board.draw(this.CreateGraphics());
			game.start();
		}

		private void setzlinge_Click(object sender, EventArgs e)
		{
			setzlingReady = true;
		}
	}
}