namespace ForestSpirits.Business
{
	public class GameConfiguration
	{
		public int resourceMax = 100;
		public int resourceMin = 0;
		public int co2StartValue = 5000;
		public int fieldRows = 3;
		public int fieldColumns = 3;
		public Coordinate cityStart = new Coordinate(2, 2);
		public int resourceAdmissionRate = 10;
		public readonly int co2High = 4000;
		public readonly int co2Low = 2000;
		public int co2Reduction = 100;
		public int co2Increase = 100;
	}
}