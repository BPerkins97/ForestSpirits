using System.Drawing;

// Only works for perfect hexagons
namespace ForestSpirits.Frontend
{
	internal class Board
	{
		private const double WIDTH_TO_HEIGHT = 829.0 / 718.0;
		private const int IMAGE_WIDTH = 111;
		private const int IMAGE_HEIGHT = (int)(IMAGE_WIDTH * WIDTH_TO_HEIGHT);
		public readonly int rows;
		public readonly int columns;
		private FieldMapper mapper;
		private Image image;

		public Board(int rows, int columns)
		{
			this.rows = rows;
			this.columns = columns;
			image = FileUtils.loadImage("Zweieck.png");
			image = FileUtils.resizeImage(image, IMAGE_WIDTH, IMAGE_HEIGHT);
			mapper = new FieldMapper(rows, columns, IMAGE_WIDTH, IMAGE_HEIGHT);
		}

		public void draw(Graphics graphics)
		{
			float heightDiff = (float)(mapper.fieldHeight * 0.75);
			for (float y = 0; y < rows / 2.0; y++) // This float: rows / 2.0 is on purpose!
			{
				for (float x = 0; x < columns; x++)
				{
					graphics.DrawImage(image, x * mapper.fieldWidth, y * 2 * heightDiff);
				}
			}
			for (float y = 0; y < rows / 2; y++)
			{
				for (float x = 0; x < columns; x++)
				{
					graphics.DrawImage(image, x * mapper.fieldWidth + mapper.fieldWidth / 2, y * 2 * heightDiff + heightDiff);
				}
			}
		}

		public Coordinate getCoordinates(float x, float y)
		{
			return mapper.pointToCoordinate(x, y);
		}
	}

	internal class FieldMapper
	{
		public readonly float fieldWidth;
		public readonly float fieldHeight;
		public readonly int rows;
		public readonly int columns;

		public FieldMapper(int rows, int columns, float fieldWidth, float fieldHeight)
		{
			this.fieldWidth = fieldWidth;
			this.fieldHeight = fieldHeight;
			this.rows = rows;
			this.columns = columns;
		}

		public Coordinate pointToCoordinate(float x, float y)
		{
			bool found = false;
			Coordinate result = new Coordinate(-1, -1);
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					if (!found && isSelected(j, i, x, y))
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

	internal class Coordinate
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