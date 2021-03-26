using ForestSpirits.Business;

namespace ForestSpirits.business
{
	public class Field
	{
		public readonly Plant plant;
		public readonly FieldType type;
		public readonly int sunStorage;
		public readonly int waterStorage;

		public Field()
        {
			plant = null;
			type = FieldType.NORMAL;
			sunStorage = 0;
			waterStorage = 0;
        }

		public Field(Plant plant, FieldType type, int sunStorage, int waterStorage) 
        {
			this.plant = plant;
			this.type = type;
			this.sunStorage = sunStorage;
			this.waterStorage = waterStorage;
        }

		public Field withPlant(Plant plant)
        {
			return new Field(plant, type, sunStorage, waterStorage);
        }

		public Field withType(FieldType type)
		{
			return new Field(plant, type, sunStorage, waterStorage);
		}

		public Field withSunStorage(int sunStorage)
		{
			return new Field(plant, type, sunStorage, waterStorage);
		}

		public Field withWaterStorage(int waterStorage)
		{
			return new Field(plant, type, sunStorage, waterStorage);
		}
	}
}
