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
            return ShiftAndWrap(X.GetHashCode(), 2) ^ Y.GetHashCode();
        }

        // https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.8
        private int ShiftAndWrap(int value, int positions)
        {
            positions = positions & 0x1F;

            // Save the existing bit pattern, but interpret it as an unsigned integer.
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            // Preserve the bits to be discarded.
            uint wrapped = number >> (32 - positions);
            // Shift and wrap the discarded bits.
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }

        public override string ToString()
        {
            return $"({this.X},{this.Y})";
        }
    }
}
