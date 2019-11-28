using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Model.Types
{
    public class SkillCategory
    {
        public string Name { get; set; }
        public string TypeString { get; set; }

        public static SkillCategory General = new SkillCategory() { Name = "General", TypeString = "G" };
        public static SkillCategory Agility = new SkillCategory() { Name = "Agility", TypeString = "A" };
        public static SkillCategory Passing = new SkillCategory() { Name = "Passing", TypeString = "P" };
        public static SkillCategory Strength = new SkillCategory() { Name = "Strength", TypeString = "S" };
        public static SkillCategory Mutation = new SkillCategory() { Name = "Mutation", TypeString = "M" };
        public static SkillCategory Extraordinary = new SkillCategory() { Name = "Extraordinary", TypeString = "E" };
        public static SkillCategory StatIncrease = new SkillCategory() { Name = "Stat Increase", TypeString = "+" };
        public static SkillCategory StatDecrease = new SkillCategory() { Name = "Stat Decrease", TypeString = "-" };
    }
}
