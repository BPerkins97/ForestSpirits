namespace ForestSpirits.Business
{
	public class GameConfiguration
	{
		public int resourceMax = 100;
		public int resourceMin = 0;
		public int co2StartValue = 5000;
		public int fieldRows = 5;
		public int fieldColumns = 5;
		public Coordinate cityStart = new Coordinate(3,3);
		public int resourceAdmissionRate = 5;
		public readonly int co2High = 4000;
		public readonly int co2Low = 2000;
		public int co2Reduction = 100;
		public int co2Increase = 100;
	}
}