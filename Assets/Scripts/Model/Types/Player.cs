using Fumbbl.View;
using System.Collections.Generic;

namespace Fumbbl.Model.Types
{
    public class Player : ViewObject<Player>
    {
        public string Id;
        public string PositionId;
        public string Name;
        public Types.Coordinate Coordinate { get; set; }

        public Gender Gender;
        public Team Team { get; set; }
        public PlayerState PlayerState { get; internal set; }
        public SeriousInjury SeriousInjury { get; internal set; }
        public Position Position { get; internal set; }
        public int Movement { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Armour { get; set; }
        public int Spp { get; internal set; }
        public List<string> Skills { get; set; }


        public override object Key => Id;
        public bool IsHome => Team.IsHome;

        public string Level
        {
            get
            {
                if (Spp > 175) { return "Legend"; }
                if (Spp > 75) { return "Super Star"; }
                if (Spp > 50) { return "Star"; }
                if (Spp > 30) { return "Emerging Star"; }
                if (Spp > 15) { return "Veteran"; }
                return "Rookie";
            }
        }

        public override void Refresh(Player data)
        {
            Id = data.Id;
            PositionId = data.PositionId;
            Name = data.Name;
            Coordinate = data.Coordinate;
            Gender = data.Gender;
            Team = data.Team;
            PlayerState = data.PlayerState;
            SeriousInjury = data.SeriousInjury;
            Position = data.Position;
            Movement = data.Movement;
            Strength = data.Strength;
            Agility = data.Agility;
            Armour = data.Armour;
        }

        public Player()
        {
            Team = new Team();
            Skills = new List<string>();
        }

        public string FormattedName
        {
            get
            {
                string color = IsHome ? "#ff0000" : "#0000ff";
                return $"<color={color}>{TextPanelHandler.SanitizeText(Name)}</color>";
            }
        }

        internal bool HasSkill(SkillType skillType)
        {
            return false;
        }

    }
}
