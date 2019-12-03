using Fumbbl.View;

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

        public override object Key => Id;
        public bool IsHome => Team.IsHome;

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
            Coordinate = new Coordinate(0, 0);
        }

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
