using System;

namespace Fumbbl.Model.Types
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        private Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coordinate Create(int[] coordinates)
        {
            if (coordinates == null)
            {
                return null;
            }
            if (coordinates.Length != 2)
            {
                throw new ArgumentException(String.Format("Invalid coordinate int[]: {0}", coordinates), "coordinates");
            }
            return new Coordinate(coordinates[0], coordinates[1]);

        }

        public static Coordinate Create(int x, int y)
        {
            return new Coordinate(x, y);
        }

        public bool Equals(Coordinate other)
        {
            return other != null && other.X == this.X && other.Y == this.Y;
        }

        public override string ToString()
        {
            return $"({this.X},{this.Y})";
        }
    }
}
