using System.Collections.Generic;

namespace Fumbbl.Model.Types
{
    public class Position
    {
        public string Id { get; set; }
        public string AbstractLabel { get; set; }
        public string IconURL { get; set; }
        public string PortraitURL { get; set; }
        public string Name { get; internal set; }
        public List<string> Skills { get; set; }
        public Dictionary<string, int> Skillvalue { get; set; }

        public Position()
        {
            Skills = new List<string>();
            Skillvalue = new Dictionary<string, int>();
        }
    }
}
