namespace Fumbbl.Model.Types
{
    public class PlayerAction : FfbEnumerationFactory
    {
        public PlayerAction(string name) : base(name) { }

        public string Action => Name;
        public int Type { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool ShowActivity => Description != null;

        public static PlayerAction move = new PlayerAction("move") { ShortDescription="Move", Description = "starts a Move Action" };
        public static PlayerAction block = new PlayerAction("block") { ShortDescription = "Block", Description = "starts a Block Action" };
        public static PlayerAction blitz = new PlayerAction("blitz");
        public static PlayerAction blitzMove = new PlayerAction("blitzMove") { ShortDescription = "Blitz", Description = "starts a Blitz Action" };
        public static PlayerAction handOver = new PlayerAction("handOver");
        public static PlayerAction handOverMove = new PlayerAction("handOverMove") { ShortDescription = "Hand Over", Description = "starts a Hand Over Action" };
        public static PlayerAction pass = new PlayerAction("pass");
        public static PlayerAction passMove = new PlayerAction("passMove") { ShortDescription = "Pass", Description = "starts a Pass Action" };
        public static PlayerAction foul = new PlayerAction("foul");
        public static PlayerAction foulMove = new PlayerAction("foulMove") { ShortDescription = "Foul", Description = "starts a Foul Action" };
        public static PlayerAction standUp = new PlayerAction("standUp") { ShortDescription = "Stand Up", Description = "stands up" };
        public static PlayerAction throwTeamMate = new PlayerAction("throwTeamMate");
        public static PlayerAction throwTeamMateMove = new PlayerAction("throwTeamMateMove");
        public static PlayerAction removeConfusion = new PlayerAction("removeConfusion");
        public static PlayerAction gaze = new PlayerAction("gaze");
        public static PlayerAction multipleBlock = new PlayerAction("multipleBlock") { ShortDescription = "Block", Description = "starts a Block Action" };
        public static PlayerAction hailMaryPass = new PlayerAction("hailMaryPass");
        public static PlayerAction dumpOff = new PlayerAction("dumpOff");
        public static PlayerAction standUpBlitz = new PlayerAction("standUpBlitz") { ShortDescription = "Blitz", Description = "stands up with Blitz" };
        public static PlayerAction throwBomb = new PlayerAction("throwBomb") { ShortDescription = "Bomb", Description = "starts a Bomb Action" };
        public static PlayerAction hailMaryBomb = new PlayerAction("hailMaryBomb");
        public static PlayerAction swoop = new PlayerAction("swoop");
    }
}
