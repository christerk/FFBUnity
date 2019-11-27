namespace Fumbbl.Ffb.Dto.Commands
{
    public class Player
    {
        public string playerId;
        public int playerNr;
        public string positionId;
        public string playerName;
        public FFBEnumeration playerGender;
        public FFBEnumeration playerType;

        public int movement;
        public int strength;
        public int agility;
        public int armour;

        public FFBEnumeration[] lastingInjuries;
        public FFBEnumeration recoveringInjury;

        public string urlPortrait;
        public string urlIconSet;
        public int nrOfIcons;
        public int positionIconIndex;

        public FFBEnumeration[] skillArray;
    }
}