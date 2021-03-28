using System;
using Fumbbl.Model.Types;
using TMPro;

namespace Fumbbl.View
{
    public class TrackNumber : IKeyedObject<TrackNumber>
    {
        private object key;
        private Fumbbl.Model.Types.Coordinate coordinate;
        public Fumbbl.Model.Types.Coordinate Coordinate
        {
            get { return coordinate; }
            set
            {
                key = value.X * 100 + value.Y;
                coordinate = value;
            }
        }
        public int Number;
        internal bool Active;

        public object Key => key;

        public TextMeshPro LabelObject { get; internal set; }

        public TrackNumber()
        {
        }

        public void Set(TrackNumber trackNumber)
        {
            Coordinate = trackNumber.Coordinate;
            Number = trackNumber.Number;
            Active = true;
        }

        public void Unset()
        {
            Active = false;
        }

        internal void Set(Ffb.Dto.ModelChanges.TrackNumber trackNumber)
        {
            Coordinate = Coordinate.Create(trackNumber.coordinate);
            Number = trackNumber.number;
            Active = true;
        }
    }
}
