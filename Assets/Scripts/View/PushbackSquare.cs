using Fumbbl.Model.Types;
using System;

namespace Fumbbl.View
{
    public class PushbackSquare : IKeyedObject<PushbackSquare>
    {
        public Coordinate Coordinate { get; set; }
        public string Direction;
        public bool HomeChoice;
        public bool Locked;
        public bool Selected;
        internal bool Active;

        public object Key => Coordinate.X * 100 + Coordinate.Y;
 
        public PushbackSquare()
        {
        }

        public void Set(PushbackSquare square)
        {
            Coordinate = square.Coordinate;
            Direction = square.Direction;
            HomeChoice = square.HomeChoice;
            Locked = square.Locked;
            Selected = square.Selected;
            Active = true;
        }

        public void Unset()
        {
            Active = false;
        }

        internal void Set(Ffb.Dto.ModelChanges.PushbackSquare square)
        {
            Coordinate = Coordinate.Create(square.coordinate);
            Direction = square.direction.key;
            HomeChoice = square.homeChoice;
            Locked = square.locked;
            Selected = square.selected;
            Active = true;
        }
    }
}
