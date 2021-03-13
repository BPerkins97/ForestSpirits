using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Threading;
using ForestSpirits.Business;
using Frontend.business;
using System.Threading;

namespace ForestSpirits.Frontend
{
	public partial class Spielfenster : Form, GameWindow
	{
		private GameEngine game;
		private Board board;

		public Spielfenster()
		{
			InitializeComponent();
			game = new GameEngine(this);

			this.board = new Board(9, 16);
		}

		public void showGameState(GameState gameState)
		{
			this.lSpielzeitWert.Text = gameState.time;
			this.lCo2LevelWert.Text = "" + gameState.co2;
		}

		private void onClick(object sender, MouseEventArgs e)
		{
			Coordinate coordinate = board.getCoordinates(e.X, e.Y);
			MessageBox.Show(coordinate.x + "|" + coordinate.y);
		}

        private void start(object sender, EventArgs e)
        {
			board.draw(this.CreateGraphics());
			game.start();
		}
    }
}