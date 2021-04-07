

namespace ForestSpirits.Business
{
    public class Plant
	{
        public readonly int waterStorage;
        public readonly int sunStorage;
        public int progress;

        public Plant()
        {
            waterStorage = 0;
            sunStorage = 0;
            progress = 0;
        }

        public Plant(int sunStorage, int waterStorage, int progress)
        {
            this.sunStorage = sunStorage;
            this.waterStorage = waterStorage;
            this.progress = progress;
        }

        public Plant withSun(int sunStorage)
        {
            return new Plant(sunStorage, waterStorage, progress);
        }

        public Plant withWater(int waterStorage)
        {
            return new Plant(sunStorage, waterStorage, progress);
        }

        public Plant withProgress(int progress)
        {
            return new Plant(sunStorage, waterStorage, progress);
        }
    }
}