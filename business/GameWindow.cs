using System.Collections.Generic;

namespace ForestSpirits.Business
{
	internal interface GameWindow
	{
		void showGameState(GameState gameState);
	}

	public class GameState
	{
		public string time;
		public int co2;
		public bool sonneZumSammeln;
		public bool wasserZumSammeln;
		public Inventar inventar;
		public PflanzenRegister pflanzenRegister;

		public GameState()
		{
			inventar = new Inventar();
			pflanzenRegister = new PflanzenRegister();
		}
	}

	public class PflanzenRegister
	{
		public List<Setzling> setzlinge;

		public PflanzenRegister()
		{
			this.setzlinge = new List<Setzling>();
		}
	}

	public class Inventar
	{
		public int sonne;
		public int wasser;
		public int setzlinge = 99;
	}
}