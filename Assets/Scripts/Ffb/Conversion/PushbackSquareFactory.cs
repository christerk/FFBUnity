using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Ffb.Conversion
{
    public static class PushbackSquareFactory
    {
        public static PushbackSquare PushbackSquare(Ffb.Dto.ModelChanges.PushbackSquare pushbackSquare)
        {
            return new PushbackSquare()
            {
                Coordinate = Coordinate.Create(pushbackSquare.coordinate),
                Direction = pushbackSquare.direction.key
            };
        }
    }
}
