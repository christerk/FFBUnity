using System;

namespace Fumbbl.Model.Types
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int[] coordinates)
        {
            if (coordinates.Length != 2)
            {
                throw new ArgumentException(String.Format("Invalid coordinate int[]: {0}", coordinates), "coordinates");
            }
            X = coordinates[0];
            Y = coordinates[1];
        }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
