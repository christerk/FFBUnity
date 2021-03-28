using Fumbbl.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Model.Types
{
    public class TrackNumber : IKeyedObject<TrackNumber>
    {
        private object key;

        public Coordinate Coordinate;
        public int Number;

        public bool Active { get; internal set; }

        public object Key => key;

        public void Unset()
        {
            Active = false;
        }

        public void Set(TrackNumber trackNumber)
        {
            Coordinate = trackNumber.Coordinate;
            Number = trackNumber.Number;
            Active = true;
            key = Coordinate.X * 100 + Coordinate.Y;
        }
    }
}
