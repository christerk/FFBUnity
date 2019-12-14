using System;

namespace Fumbbl.Model.Types
{
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate(int x, int y)
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

        public override bool Equals(Object obj)
        {
           if (! (obj is Coordinate)) return false;

           Coordinate p = (Coordinate)obj;
           return X == p.X & Y == p.Y;
        }

        public override int GetHashCode()
        {
            // weighting the coordinates to ensure unique hash code over the set of possible coordinates of the game board
            return (10000 * Y + X).GetHashCode();
        }

        public override string ToString()
        {
            return $"({this.X},{this.Y})";
        }
    }
}
