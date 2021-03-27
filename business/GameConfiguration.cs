namespace ForestSpirits.Business
{
    public class GameConfiguration
    {
        public int resourceMax = 100;
        public int resourceMin = 0;
        public int co2StartValue = 5000;
        public int fieldRows = 2;
        public int fieldColumns = 2;
        public Coordinate cityStart = new Coordinate(1,1);
        public int resourceAdmissionRate = 10;
    }
}