using ForestSpirits.Business;
using System;
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
		private Image ripeFieldImg;
		private Image halfRipeFieldImg;
		private Image cityImg;
		private Image treeImg;
		private Image seedlingImg;

		public Board(int rows, int columns)
		{
			this.rows = rows;
			this.columns = columns;

			feldImg = loadImg("field_default.png");
			ripeFieldImg = loadImg("field_ripe.png");
			halfRipeFieldImg = loadImg("field_half_ripe.png");
			cityImg = loadImg("field_city.png");
			treeImg = loadImg("field_tree.png");
			seedlingImg = loadImg("field_seedling.png");
			mapper = new FieldMapper(rows, columns, IMAGE_WIDTH, IMAGE_HEIGHT);
		}

        private Image loadImg(string fileName)
        {
			Image img = FileUtils.loadImage(fileName);
			img = FileUtils.resizeImage(img, IMAGE_WIDTH, IMAGE_HEIGHT);
			return img;
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

		public void drawField(Coordinate coord, FieldType type, Graphics graphics)
        {
			Image img = getFieldImage(type);
			
			Point point = getPoint(coord);
			graphics.DrawImage(img, point);
			width = Math.Max(width, point.X + IMAGE_WIDTH);
			height = Math.Max(height, point.Y + IMAGE_HEIGHT);
		}

		private Image getFieldImage(FieldType type)
        {
			switch (type)
			{
				case FieldType.NORMAL:
					return feldImg;
				case FieldType.MEDIUM:
					return halfRipeFieldImg;
				case FieldType.HIGH:
					return ripeFieldImg;
				case FieldType.CITY:
					return cityImg;
				case FieldType.SEEDLING:
					return seedlingImg;
				case FieldType.TREE:
					return treeImg;
				default:
					throw new Exception();
			}
		}

		public Coordinate getCoordinates(float x, float y)
		{
			return mapper.pointToCoordinate(x, y);
		}

		public Point getPoint(Coordinate coordinate)
		{
			// Holt die Pixel Koordinaten von einer Kachel-Koordiante. Das umgekehrte von getCoordinate()
			int x = coordinate.row;
			int y = coordinate.column;
			float heightDiff = (float)(mapper.fieldHeight * 0.75);

			if (y % 2 == 0 || y == 0)
			{
				float xPixel = x * mapper.fieldWidth;
				float yPixel = y * heightDiff;
				return new Point((int)(xPixel), (int)(yPixel));
			}
			else // (y % 2 != 0)
			{
				float xPixel = x * mapper.fieldWidth + mapper.fieldWidth / 2;
				float yPixel = y * heightDiff;
				return new Point((int)(xPixel), (int)(yPixel));
			}
		}

        internal void drawCity(Coordinate coordinate)
        {
            throw new NotImplementedException();
        }

        public float getfieldWidth()
		{
			return this.mapper.fieldWidth;
		}

		public float getFieldHeight()
		{
			return this.mapper.fieldHeight;
		}

		public SizeF getSize()
		{
			return new SizeF(width, height);
		}

        internal void drawField(Coordinate coordinate, Business.FieldType level)
        {
            throw new NotImplementedException();
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
						result = new Coordinate(j, i);
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
}