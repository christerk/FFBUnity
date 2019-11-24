using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Model
{
    public class Gender
    {
        public string Genetive { get; private set; }
        public string Dative { get; private set; }

        public static Gender Male = new Gender()
        {
            Genetive = "his",
            Dative = "him",
        };

    }
}
