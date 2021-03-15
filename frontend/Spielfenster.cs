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
		private GameState lastGameState;
		private Image sonneImg;
		private Image wasserImg;

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
		}

		public void showGameState(GameState gameState)
		{
			this.lSpielzeitWert.Text = gameState.time;
			this.lCo2LevelWert.Text = "" + gameState.co2;
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

			this.sonne.Text = "Sonne " + gameState.inventar.sonne;
			this.wasser.Text = "Wasser " + gameState.inventar.wasser;
			lastGameState = gameState;
		}

		private void onClick(object sender, MouseEventArgs e)
		{
			if (e.X > sonneLocation.X && e.X < sonneLocation.X + sonneWidth && e.Y > sonneLocation.Y && e.Y < sonneLocation.Y + sonneWidth)
			{
				game.sammleSonne();
				Graphics graphics = this.CreateGraphics();
				graphics.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height));
				board.draw(graphics);
			}
			if (e.X > wasserLocation.X && e.X < wasserLocation.X + sonneWidth && e.Y > wasserLocation.Y && e.Y < wasserLocation.Y + sonneWidth)
			{
				game.sammleWasser();
				Graphics graphics = this.CreateGraphics();
				graphics.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height));
				board.draw(graphics);
			}
			else
			{
				Coordinate coordinate = board.getCoordinates(e.X, e.Y);
			}
		}

		private void start(object sender, EventArgs e)
		{
			board.draw(this.CreateGraphics());
			game.start();
		}
	}
}