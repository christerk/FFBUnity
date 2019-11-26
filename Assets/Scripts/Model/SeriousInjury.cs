using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Model
{
    public class SeriousInjury
    {
        private static Dictionary<string, SeriousInjury> SeriousInjuries = new Dictionary<string, SeriousInjury>();
        public string Name { get; private set; }

        private SeriousInjury(string name)
        {
            Name = name;
        }

        public static SeriousInjury Get(string name)
        {
            if (!SeriousInjuries.ContainsKey(name))
            {
                SeriousInjuries.Add(name, new SeriousInjury(name));
            }

            return SeriousInjuries[name];
        }
    }
}
