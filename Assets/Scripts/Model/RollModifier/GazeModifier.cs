namespace Fumbbl.Model.RollModifier
{
    public class GazeModifier : AbstractModifier
    {
        public GazeModifier(string name, int modifier) : base(name, modifier) { }

        public static GazeModifier Tacklezone1 = new GazeModifier("1 Tacklezone", 1) { ShowModifier = false };
        public static GazeModifier Tacklezone2 = new GazeModifier("2 Tacklezones", 2) { ShowModifier = false };
        public static GazeModifier Tacklezone3 = new GazeModifier("3 Tacklezones", 3) { ShowModifier = false };
        public static GazeModifier Tacklezone4 = new GazeModifier("4 Tacklezones", 4) { ShowModifier = false };
        public static GazeModifier Tacklezone5 = new GazeModifier("5 Tacklezones", 5) { ShowModifier = false };
        public static GazeModifier Tacklezone6 = new GazeModifier("6 Tacklezones", 6) { ShowModifier = false };
        public static GazeModifier Tacklezone7 = new GazeModifier("7 Tacklezones", 7) { ShowModifier = false };
        public static GazeModifier Tacklezone8 = new GazeModifier("8 Tacklezones", 8) { ShowModifier = false };
    }
}