namespace Fumbbl.Ffb.Dto.Commands
{
    public class Position
    {
        public string positionId;
        public string positionName;
        public string shorthand;
        public string displayName;
        public FFBEnumeration playerType;
        public FFBEnumeration playerGender;
        public int quantity;
        public int movement;
        public int strength;
        public int agility;
        public int armour;
        public int cost;
        public string race;
        public bool undead;
        public bool thrall;
        public string teamWithPositionId;
        public string urlPortrait;
        public string urlIconSet;
        public int nrOfIcons;

        public FFBEnumeration[] skillCategoriesNormal;
        public FFBEnumeration[] skillCategoriesDouble;
        public FFBEnumeration[] skillArray;
        public int[] skillValues;
    }
}