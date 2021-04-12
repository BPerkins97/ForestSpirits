using System;
using System.Drawing;
using System.Windows.Forms;
using ForestSpirits.Business;

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
		private bool setzlingReady = false;
		private bool sonneNehmen = false;
		private bool wasserNehmen = false;
		private Panel contextMenu;

		public Spielfenster()
		{
			InitializeComponent();
			game = new GameEngine(this);

			GameConfiguration config = new GameConfiguration();
			this.board = new Board(config.fieldRows, config.fieldColumns);
			lastGameState = GameState.createGameStateFromConfig(config);
			sonneImg = FileUtils.loadImage("sonne.png");
			sonneImg = FileUtils.resizeImage(sonneImg, sonneWidth, sonneWidth);
			wasserImg = FileUtils.loadImage("wasser.png");
			wasserImg = FileUtils.resizeImage(wasserImg, sonneWidth, sonneWidth);
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

			for (int row = 0; row < gameState.fields.GetLength(0); row++)
			{
				for (int column = 0; column < gameState.fields.GetLength(1); column++)
				{
					FieldType level = gameState.fields[row, column].type;
					board.drawField(new Coordinate(row, column), level, graphics);
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
			if (gameState.isDisasterComing)
			{
				TimeSpan timeDelta = gameState.currentDisaster.triggerTime - DateTime.Now; // spielzeit implementieren
				lDisasterWert.Text = timeDelta.ToString();
			}
			if (gameState.currentDisaster.wasTriggered)
			{
				lDisasterWert.Text = "Katastrophe ausgelöst!";
			}
			// Inventar befüllen
			this.sonne.Text = "x" + gameState.inventar.sun;
			this.wasser.Text = "x" + gameState.inventar.water;
			this.setzlinge.Text = "x" + gameState.inventar.seedlings;
			lastGameState = gameState;
		}

		private void onClick(object sender, MouseEventArgs e)
		{
			debugLastClick(e);
			if (contextMenu != null)
			{
				this.Controls.Remove(contextMenu);
			}

			if (e.X > sonneLocation.X && e.X < sonneLocation.X + sonneWidth && e.Y > sonneLocation.Y && e.Y < sonneLocation.Y + sonneWidth)
			{
				game.sammleSonne();
				resetButtons();
			}
			else if (e.X > wasserLocation.X && e.X < wasserLocation.X + sonneWidth && e.Y > wasserLocation.Y && e.Y < wasserLocation.Y + sonneWidth)
			{
				game.sammleWasser();
				resetButtons();
			}
			else if (setzlingReady)
			{
				game.setzlingPflanzen(board.getCoordinates(e.X, e.Y));
				resetButtons();
			}
			else if (sonneNehmen)
			{
				game.feedSun(board.getCoordinates(e.X, e.Y));
				resetButtons();
			}
			else if (wasserNehmen)
			{
				game.feedWater(board.getCoordinates(e.X, e.Y));
				resetButtons();
			}
			else
			{
				Coordinate coord = board.getCoordinates(e.X, e.Y);
				if (coord.row == -1)
				{
					return;
				}
				Field field = lastGameState.fields[coord.row, coord.column];
				if (field.type == FieldType.SEEDLING || field.type == FieldType.TREE)
				{
					ProgressBar water = new ProgressBar();
					water.Location = new Point(20, 100);
					water.Size = new Size(200, 20);
					water.ForeColor = Color.Aqua;
					water.Maximum = 100;
					water.Minimum = 0;
					water.Value = Math.Min(100, field.plant.waterStorage);
					ProgressBar sun = new ProgressBar();
					sun.Location = new Point(20, 50);
					sun.Size = new Size(200, 20);
					sun.ForeColor = Color.Yellow;
					sun.Maximum = 100;
					sun.Minimum = 0;
					sun.Value = Math.Min(100, field.plant.sunStorage);
					ProgressBar progress = new ProgressBar();
					progress.Location = new Point(20, 150);
					progress.Size = new Size(200, 20);
					progress.ForeColor = Color.Yellow;
					progress.Maximum = 100;
					progress.Minimum = 0;
					progress.Value = Math.Min(100, field.plant.progress);
					Label sunL = new Label();
					sunL.Text = "Sonne";
					sunL.Location = new Point(20, 20);
					Label waterL = new Label();
					waterL.Text = "Wasser";
					waterL.Location = new Point(20, 80);
					Label progressL = new Label();
					progressL.Text = "Fortschritt";
					progressL.Location = new Point(20, 130);

					contextMenu = new Panel();
					contextMenu.Controls.Add(water);
					contextMenu.Controls.Add(sun);
					contextMenu.Controls.Add(sunL);
					contextMenu.Controls.Add(waterL);
					contextMenu.Controls.Add(progress);
					contextMenu.Controls.Add(progressL);
					contextMenu.Location = new Point(e.X, e.Y);
					contextMenu.Size = new Size(240, 190);
					this.Controls.Add(contextMenu);
				}
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

        private void lSpielzeitText_Click(object sender, EventArgs e)
        {

        }

        private void lCo2LevelWert_Click(object sender, EventArgs e)
        {

        }

        private void lDisasterText_Click(object sender, EventArgs e)
        {

        }

        private void lDisasterWert_Click(object sender, EventArgs e)
        {

        }
    }
}