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
		private bool sonneNehmen = false;
		private bool wasserNehmen = false;
		private bool gameStart = true;

		public Spielfenster()
		{
			InitializeComponent();
			game = new GameEngine(this);

			this.board = new Board(3, 4);
			lastGameState = GameState.createGameStateFromConfig(new GameConfiguration());
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
			graphics.Clear(Color.Gray);


			for (int row=0;row<gameState.fields.GetLength(0);row++)
            {
				for (int column=0;column<gameState.fields.GetLength(1);column++)
                {
					if (row == 0 && column == 0)
                    {
						Console.WriteLine(gameState.fields[row, column].type);
                    }
					FieldType level = gameState.fields[row, column].type;
					board.drawField(new Coordinate(row, column), level, graphics);
					
				
					PointF fieldLocation = board.getPoint(new Coordinate(row, column));
					if (gameState.fields[row,column].type == FieldType.SEEDLING)
                    {
						PointF seedlingLoc = new PointF();
						seedlingLoc.X = fieldLocation.X + board.getfieldWidth() / 2 - setzlingImg.Width / 2;
						seedlingLoc.Y = fieldLocation.Y + board.getFieldHeight() / 2 - setzlingImg.Height / 2;
						graphics.DrawImage(setzlingImg, seedlingLoc);
					}

				}
            }

			if (gameState.isSunCollectable)
			{
				if (!lastGameState.isSunCollectable)
				{
					sonneLocation = new Point(MathUtils.random.Next(0, (int)board.getSize().Width - sonneWidth), MathUtils.random.Next(0, (int)board.getSize().Height - sonneWidth));
				}
				graphics.DrawImage(sonneImg, sonneLocation);
			}

			if (gameState.isWaterCollectable)
			{
				if (!lastGameState.isWaterCollectable)
				{
					wasserLocation = new Point(MathUtils.random.Next(0, (int)board.getSize().Width - sonneWidth), MathUtils.random.Next(0, (int)board.getSize().Height - sonneWidth));
				}
				graphics.DrawImage(wasserImg, wasserLocation);
			}
			// Inventar befüllen
			this.sonne.Text = "Sonne " + gameState.inventar.sun;
			this.wasser.Text = "Wasser " + gameState.inventar.water;
			this.setzlinge.Text = "Setzlinge " + gameState.inventar.seedlings;
			lastGameState = gameState;
			gameStart = false;
		}

		private void onClick(object sender, MouseEventArgs e)
		{
			debugLastClick(e);

			if (e.X > sonneLocation.X && e.X < sonneLocation.X + sonneWidth && e.Y > sonneLocation.Y && e.Y < sonneLocation.Y + sonneWidth)
			{
				game.sammleSonne();
				resetButtons();
			}
			if (e.X > wasserLocation.X && e.X < wasserLocation.X + sonneWidth && e.Y > wasserLocation.Y && e.Y < wasserLocation.Y + sonneWidth)
			{
				game.sammleWasser();
				resetButtons();
			}
			if (setzlingReady)
			{
				game.setzlingPflanzen(board.getCoordinates(e.X, e.Y));
				resetButtons();
			}
			if (sonneNehmen)
			{
				game.feedSun(board.getCoordinates(e.X, e.Y));
				resetButtons();
			}
			if (wasserNehmen)
			{
				game.feedWater(board.getCoordinates(e.X, e.Y));
				resetButtons();
			}
		}

		// wenn geclickt wird, sollen die Buttons nicht "aktiv" bleiben
		private void resetButtons()
		{
			this.setzlingReady = false;
			this.sonneNehmen = false;
			this.wasserNehmen = false;
		}

		private void debugLastClick(MouseEventArgs e)
		{
			// last click debug
			lLastClickPixelsWert.Text = Convert.ToString(e.Location);
			Coordinate coordinate = board.getCoordinates(e.X, e.Y);
			lLastClickCoordinatesWert.Text = $"({coordinate.row}, {coordinate.column})";
		}

		private void start(object sender, EventArgs e)
		{
			game.start();
		}

		private void setzlinge_Click(object sender, EventArgs e)
		{
			setzlingReady = true;
		}

		private void sonne_Click(object sender, EventArgs e)
		{
			sonneNehmen = true;
		}

		private void wasser_Click(object sender, EventArgs e)
		{
			wasserNehmen = true;
		}
	}
}