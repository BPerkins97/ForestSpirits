using System;

namespace ForestSpirits.Business
{
	public class Disaster
	{
		public readonly DisasterType disasterType;
		public readonly DisasterIntensity intensity;
		public readonly int disasterEffect;
		public int ressourceModifier;
		public bool wasTriggered = false;
		public readonly DateTime creationTime;
		public DateTime triggerTime;
		private Random random = new Random();

		public Disaster()
		{
		}

		public Disaster(DisasterIntensity intensity, GameConfiguration config)
		{
			this.intensity = intensity;
			creationTime = DateTime.Now;
			// Cast random coinflip to Disaster type enum
			disasterType = (DisasterType)random.Next(1, 3);

			switch (intensity)
			{
				case DisasterIntensity.HIGH:
					triggerTime = creationTime + new TimeSpan(0, 0, config.timeToDisasterHigh);
					disasterEffect = config.disasterEffectHigh;

					break;

				case DisasterIntensity.LOW:
					triggerTime = creationTime + new TimeSpan(0, 0, config.timeToDisasterLow);
					disasterEffect = config.disasterEffectLow;

					break;
			}
		}

		public Plant influencePlant(Plant plant)
		{
			int newSun = 0;
			int newWater = 0;

			switch (disasterType)
			{
				case DisasterType.HEATWAVE:
					newSun = plant.sunStorage + disasterEffect;
					// Keine negativen Zahlen!
					newWater = Math.Max(0, plant.waterStorage - disasterEffect);
					plant = plant.withSun(newSun).withWater(newWater);
					break;

				case DisasterType.RAINFALL:
					newSun = Math.Max(0, plant.sunStorage - disasterEffect);
					newWater = plant.waterStorage + disasterEffect;
					plant = plant.withSun(newSun).withWater(newWater);
					break;
			}
			return plant;
		}

		public Field influenceField(Field field)
		{
			// Zerstöre unbepflanzte Felder
			if (disasterType == DisasterType.HEATWAVE)
			{
				switch (field.type)
				{
					case FieldType.MEDIUM:
						field = field.withType(FieldType.NORMAL);
						break;

					case FieldType.HIGH:
						field = field.withType(FieldType.MEDIUM);
						break;
				}
			}

			// Regen
			if (disasterType == DisasterType.RAINFALL)
			{
				// Pilze verbreiten sich?
			}

			return field;
		}
	}

	public enum DisasterType
	{
		HEATWAVE = 1,
		RAINFALL = 2
	}

	public enum DisasterIntensity
	{
		HIGH,
		LOW,
		NONE
	}
}