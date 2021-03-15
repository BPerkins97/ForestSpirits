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
		private float width;
		private float height;
		private FieldMapper mapper;
		private Image feldImg;

		public Board(int rows, int columns)
		{
			this.rows = rows;
			this.columns = columns;
			feldImg = FileUtils.loadImage("Zweieck.png");
			feldImg = FileUtils.resizeImage(feldImg, IMAGE_WIDTH, IMAGE_HEIGHT);
			mapper = new FieldMapper(rows, columns, IMAGE_WIDTH, IMAGE_HEIGHT);
		}

		public void draw(Graphics graphics)
		{
			float heightDiff = (float)(mapper.fieldHeight * 0.75);
			for (float y = 0; y < rows / 2.0; y++) // This float: rows / 2.0 is on purpose!
			{
				for (float x = 0; x < columns; x++)
				{
					float xPixel = x * mapper.fieldWidth;
					width = xPixel + IMAGE_WIDTH > width ? xPixel + IMAGE_WIDTH : width;
					float yPixel = y * 2 * heightDiff;
					height = yPixel + IMAGE_HEIGHT > height ? yPixel + IMAGE_HEIGHT : height;
					graphics.DrawImage(feldImg, xPixel, yPixel);
				}
			}
			for (float y = 0; y < rows / 2; y++)
			{
				for (float x = 0; x < columns; x++)
				{
					float xPixel = x * mapper.fieldWidth + mapper.fieldWidth / 2;
					width = xPixel + IMAGE_WIDTH > width ? xPixel + IMAGE_WIDTH : width;
					float yPixel = y * 2 * heightDiff + heightDiff;
					height = yPixel + IMAGE_HEIGHT > height ? yPixel + IMAGE_HEIGHT : height;
					graphics.DrawImage(feldImg, xPixel, yPixel);
				}
			}
		}

		public Coordinate getCoordinates(float x, float y)
		{
			return mapper.pointToCoordinate(x, y);
		}

		public Point getPoint(Coordinate coordinate)
		{
			//unfinished
            int x = coordinate.x + 1;
			int y = coordinate.y;

			float heightDiff = (float)(mapper.fieldHeight * 0.75);
			float xPixel = x * mapper.fieldWidth;
			//int
			float width = xPixel + 111 > this.width ? xPixel + IMAGE_WIDTH : this.width;
			float yPixel = y * 2 * heightDiff;
			//int
			float height = yPixel + IMAGE_HEIGHT > this.height ? yPixel + IMAGE_HEIGHT : this.height;
			return new Point((int)(xPixel), (int)(yPixel));
		}

		public SizeF getSize()
		{
			return new SizeF(width, height);
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

		public Point coordinateToPoint(Coordinate coordinate)
		{
			//int x = coordinate.x;
			//int y = coordinate.y;

			//float heightDiff = (float)(this.fieldHeight * 0.75);
			//float xPixel = x * this.fieldWidth;
			//int width = xPixel + 111 > width ? xPixel + IMAGE_WIDTH : width;
			//float yPixel = y * 2 * heightDiff;
			//int height = yPixel + IMAGE_HEIGHT > height ? yPixel + IMAGE_HEIGHT : height;
			//graphics.DrawImage(feldImg, xPixel, yPixel);

			//float xPixel = x * this.fieldWidth;
			////width = xPixel + IMAGE_WIDTH > width ? xPixel + IMAGE_WIDTH : width;
			//float heightDiff = (float)(this.fieldHeight * 0.75);
			//float yPixel = y * 2 * heightDiff;
			////height = yPixel + IMAGE_HEIGHT > height ? yPixel + IMAGE_HEIGHT : height;
			////graphics.DrawImage(feldImg, xPixel, yPixel);
			//return new Point((int)(xPixel), (int)(yPixel));
			return new Point();
		}

		private bool isSelected(int x, int y, float actualX, float actualY)
		{
			float xBase = y % 2 == 1 ? fieldWidth / 2 : 0;
			PointF lowerLeft = new PointF(xBase + x * fieldWidth, (float)((y + 1) * 0.75 * fieldHeight));
			PointF lower = new PointF(xBase + fieldWidth / 2 + x * fieldWidth, (float)(fieldHeight + y * 0.75 * fieldHeight));
			PointF lowerRight = new PointF(xBase + x * fieldWidth + fieldWidth, (float)((y + 1) * 0.75 * fieldHeight));

			if (actualX > xBase + fieldWidth + x * fieldWidth || actualX < xBase + x * fieldWidth)
			{
				return false;
			}

			float steigung = (lower.Y - lowerLeft.Y) / (lower.X - lowerLeft.X);
			float basis = steigung * lower.X * -1 + lower.Y;

			float shouldBeY = steigung * actualX + basis;
			if (actualY > shouldBeY || actualY < shouldBeY - fieldHeight)
			{
				return false;
			}

			steigung = -steigung;
			basis = steigung * lower.X * -1 + lower.Y;

			shouldBeY = steigung * actualX + basis;
			if (actualY > shouldBeY || actualY < shouldBeY - fieldHeight)
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
