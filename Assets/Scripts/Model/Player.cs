using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Model
{
    public class Player
    {
        public string Id;
        public string Name;

        public Gender Gender;

        public bool IsHome { get { return true; } }

        public string FormattedName
        { 
            get
            {
                string color = IsHome ? "#ff0000" : "#0000ff";
                return $"<{color}>{TextPanelHandler.SanitizeText(Name)}</color>";
            }
        }

        internal bool HasSkill(SkillType skillType)
        {
            return false;
        }
    }
}
