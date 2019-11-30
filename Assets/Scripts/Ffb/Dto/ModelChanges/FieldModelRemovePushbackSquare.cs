using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Ffb.Dto.ModelChanges
{
    public class FieldModelRemovePushbackSquare : ModelChange
    {
        public PushbackSquare modelChangeValue;

        public FieldModelRemovePushbackSquare() : base("fieldModelRemovePushbackSquare") { }
    }
}
