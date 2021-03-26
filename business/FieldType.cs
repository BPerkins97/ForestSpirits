using System;

namespace ForestSpirits.Business
{
    public enum FieldType
    {
        NORMAL, 
        MEDIUM, 
        HIGH,
        CITY,
        SEEDLING,
        TREE
    }

    public class FieldLevelFactory
    {
        public static FieldType nextLevel(FieldType level)
        {
            switch(level)
            {
                case FieldType.NORMAL:
                    return FieldType.MEDIUM;
                case FieldType.MEDIUM:
                    return FieldType.HIGH;
                default:
                    throw new FieldAlreadyAtHighestLevelException();
            }
        }

        public static bool isPlantable(FieldType level)
        {
            return level == FieldType.HIGH;
        }
    }

    public class FieldAlreadyAtHighestLevelException : Exception
    {

    }
}