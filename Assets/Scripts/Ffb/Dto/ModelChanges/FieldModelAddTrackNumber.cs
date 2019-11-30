using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Ffb.Dto.ModelChanges
{
    public class FieldModelAddTrackNumber : ModelChange
    {
        public TrackNumber modelChangeValue;

        public FieldModelAddTrackNumber() : base("fieldModelAddTrackNumber") { }
    }
}
