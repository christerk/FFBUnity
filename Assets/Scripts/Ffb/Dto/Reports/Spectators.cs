namespace Fumbbl.Ffb.Dto.Reports
{
    public class Spectators : Report
    {
        public int[] spectatorRollHome;
        public int spectatorsHome;
        public int fameHome;
        public int[] spectatorRollAway;
        public int spectatorsAway;
        public int fameAway;

        public Spectators() : base("spectators") { }
    }
}
