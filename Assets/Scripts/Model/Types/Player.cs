using Fumbbl.View;
using System.Collections.Generic;

namespace Fumbbl.Model.Types
{
    public class Player : IKeyedObject<Player>
    {
        public Gender Gender;
        public List<string> Skills { get; set; }
        public PlayerState PlayerState { get; internal set; }
        public Position Position { get; internal set; }
        public SeriousInjury SeriousInjury { get; internal set; }
        public Team Team { get; set; }
        public Types.Coordinate Coordinate { get; set; }
        public int Agility { get; set; }
        public int Armour { get; set; }
        public int Movement { get; set; }
        public int Spp { get; internal set; }
        public int Strength { get; set; }
        public string Id;
        public string Name;
        public string PortraitURL;
        public string PositionId;

        public object Key => Id;
        public bool IsHome => Team.IsHome;

        public string FormattedName
        {
            get
            {
                var colorsettings = FFB.Instance.Settings.Color;
                string color = IsHome ? colorsettings.HomeColor : colorsettings.AwayColor;
                return $"<color={color}>{TextPanelHandler.SanitizeText(Name)}</color>";
            }
        }

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

        public Player()
        {
            Team = new Team();
            Skills = new List<string>();
        }

        internal bool HasSkill(SkillType skillType)
        {
            return false;
        }

        public void Refresh(Player data)
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
    }
}
