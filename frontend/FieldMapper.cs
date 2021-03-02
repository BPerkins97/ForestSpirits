using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Only works for perfect hexagons
namespace Frontend
{
    class FieldMapper {
        private float fieldWidth;
        private float fieldHeight;
        private int rows;
        private int columns;

        public FieldMapper(int rows, int columns, float fieldWidth, float fieldHeight) 
        {
            this.fieldWidth = fieldWidth;
            this.fieldHeight = fieldHeight;
            this.rows = rows;
            this.columns = columns;
        }

        public Coordinate pointToCoordinate(PointF point)
        {
            bool found = false;
            Coordinate result = new Coordinate(-1, -1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (!found && isSelected(j, i, point.X, point.Y))
                    {
                        result = new Coordinate(i, j);
                        found = true;
                    }
                }
            }
            return result;
        }

        private bool isSelected(int x, int y, float actualX, float actualY)
        {
            float xBase = y % 2 == 1 ? fieldWidth / 2 : 0;
            PointF lowerLeft = new PointF(xBase + x * fieldWidth, (float)((y + 1) * 0.75 * fieldHeight));
            PointF lower = new PointF(xBase + fieldWidth / 2 + x * fieldWidth, (float)(fieldHeight + y * 0.75 * fieldHeight));

            float steigung = (lower.Y - lowerLeft.Y) / (lower.X - lowerLeft.X);
            float basis = steigung * lower.X * -1 + lower.Y;

            float shouldBeY = steigung * actualX + basis;
            if (actualY > shouldBeY)
            {
                return false;
            }

            steigung = -steigung;
            basis = steigung * lower.X * -1 + lower.Y;

            shouldBeY = steigung * actualX + basis;
            if (actualY > shouldBeY)
            {
                return false;
            }

            if (actualX > xBase + fieldWidth + x * fieldWidth)
            {
                return false;
            }
            return true;
        }
    }

    class Coordinate
    {
        public readonly int x;
        public readonly int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
