using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Ffb.Conversion
{
    public static class MoveSquareFactory
    {
        public static MoveSquare MoveSquare(Ffb.Dto.ModelChanges.MoveSquare moveSquare)
        {
            return new MoveSquare()
            {
                Coordinate = Coordinate.Create(moveSquare.coordinate),
                Number = moveSquare.number
            };
        }
    }
}
