namespace Fumbbl.Ffb.Dto.Commands
{
    public class Roster
    {
        public string rosterId;
        public string rosterName;
        public int reRollCost;
        public int maxReRolls;
        public string baseIconPath;
        public string logoUrl;
        public string raisedPositionId;
        public bool apothecary;
        public bool necromancer;
        public bool undead;

        public Position[] positionArray;
    }
}