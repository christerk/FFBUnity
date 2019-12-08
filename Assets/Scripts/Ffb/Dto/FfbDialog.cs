using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Ffb.Dto
{
    public abstract class FfbDialog : ReflectedGenerator<string>
    {
        public FfbDialog(string key) : base(key) { }
    }
}
