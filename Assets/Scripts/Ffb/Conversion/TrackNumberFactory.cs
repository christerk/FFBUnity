using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Ffb.Conversion
{
    public static class TrackNumberFactory
    {
        public static TrackNumber TrackNumber(Ffb.Dto.ModelChanges.TrackNumber trackNumber)
        {
            return new TrackNumber()
            {
                Coordinate = Coordinate.Create(trackNumber.coordinate),
                Number = trackNumber.number
            };
        }
    }
}
