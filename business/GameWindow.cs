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
		public feldRegister feldRegister;

		public GameState()
		{
			inventar = new Inventar();
			pflanzenRegister = new PflanzenRegister();
			feldRegister = new feldRegister();
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

    public class feldRegister
    {
        public List<Feld> felder;

        public feldRegister()
        {
            this.felder = new List<Feld>();
        }
    }

    public class Inventar
	{
		public int sonne;
		public int wasser;
		public int setzlinge = 99;
		public int pilze;
	}
}