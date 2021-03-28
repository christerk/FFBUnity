using Fumbbl.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Model.Types
{
    public class PushbackSquare : IKeyedObject<PushbackSquare>
    {
        private object key;
        public Coordinate Coordinate;
        public string Direction;
        private bool HomeChoice;
        private bool Locked;
        private bool Selected;
        internal bool Active;

        public object Key => key;

        public void Unset()
        {
            Active = false;
        }

        public void Set(PushbackSquare square)
        {
            Coordinate = square.Coordinate;
            Direction = square.Direction;
            HomeChoice = square.HomeChoice;
            Locked = square.Locked;
            Selected = square.Selected;
            Active = true;

            key = Coordinate.X * 100 + Coordinate.Y;
        }
    }
}
