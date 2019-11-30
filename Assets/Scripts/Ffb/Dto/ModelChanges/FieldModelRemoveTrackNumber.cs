using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Ffb.Dto.ModelChanges
{
    public class FieldModelRemoveTrackNumber : ModelChange
    {
        public TrackNumber modelChangeValue;

        public FieldModelRemoveTrackNumber() : base("fieldModelRemoveTrackNumber") { }
    }
}
