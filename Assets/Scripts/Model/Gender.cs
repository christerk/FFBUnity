using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Model
{
    public class Gender
    {
        public string Genetive;

        public static Gender Male = new Gender()
        {
            Genetive = "his"
        };
    }
}
