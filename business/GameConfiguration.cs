namespace ForestSpirits.Business
{
    public class GameConfiguration
    {
        public int resourceMax = 100;
        public int resourceMin = 0;
        public int co2StartValue = 5000;
        public int fieldRows = 3;
        public int fieldColumns = 3;
        public Coordinate cityStart = new Coordinate(2,2);
        public int resourceAdmissionRate = 10;
    }
}