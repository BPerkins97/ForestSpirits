using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSpirits.Business
{
	public class Disaster
	{
		public readonly DisasterType type;
		public readonly DisasterIntensity intensity;
		public int ressourceModifier;
		public bool wasTriggered = false;
		public readonly DateTime creationTime;
		public DateTime triggerTime;

		public Disaster()
		{
		}

		public Disaster(DisasterType type, DisasterIntensity intensity)
		{
			this.type = type;
			this.intensity = intensity;
			creationTime = DateTime.Now;

			switch (intensity) // implement config for times
			{
				case DisasterIntensity.HIGH:
					triggerTime = creationTime + new TimeSpan(0, 0, 20);
					ressourceModifier = 500;
					break;

				case DisasterIntensity.LOW:
					triggerTime = creationTime + new TimeSpan(0, 0, 60);
					break;
			}
		}

		public Plant damagePlant(Plant plant)
		{
			// Reduziere Ressourcen von Pflanze
			return plant;
		}

		public Field damageField(Field field)
		{
			// Zerstöre unbepflanzte Felder
			if (this.type == DisasterType.HEATWAVE)
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

			return field;
		}
	}

	public enum DisasterType
	{
		HEATWAVE,
		RAINFALL
	}

	public enum DisasterIntensity
	{
		HIGH,
		LOW,
		NONE
	}
}