

namespace ForestSpirits.Business
{
    public interface Plant
    {
        Plant withSun(int sun);
        Plant withWater(int water);

    }

    public class Seedling : Plant
	{
        public readonly int waterStorage;
        public readonly int sunStorage;

        public Seedling()
        {
            waterStorage = 0;
            sunStorage = 0;
        }

        public Seedling(int sunStorage, int waterStorage)
        {
            this.sunStorage = sunStorage;
            this.waterStorage = waterStorage;
        }

        public Plant withSun(int sunStorage)
        {
            return new Seedling(sunStorage, waterStorage);
        }

        public Plant withWater(int waterStorage)
        {
            return new Seedling(sunStorage, waterStorage);
        }
    }
}