namespace Fumbbl.Ffb.Dto.Commands
{
    public class FieldModel
    {
        public string weather;
        public int[] ballCoordinate;
        public bool ballInPlay;
        public bool ballMoving;
        public int[] bombCoordinate;
        public bool bombMoving;

        public PlayerData[] playerDataArray;
    }
}