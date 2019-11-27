namespace Fumbbl.Ffb.Dto.Commands
{
    public class Team
    {
        public string teamId;
        public string teamName;
        public string coach;
        public string race;
        public int reRolls;
        public int apothecaries;
        public int cheerleaders;
        public int assistantCoaches;
        public int fanFactor;
        public int teamValue;
        public int treasury;
        public string baseIconPath;
        public string logoUrl;

        public Player[] playerArray;

        public Roster roster;
    }
}