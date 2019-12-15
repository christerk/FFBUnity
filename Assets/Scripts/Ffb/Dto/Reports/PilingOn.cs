namespace Fumbbl.Ffb.Dto.Reports
{
    public class PilingOn : Report
    {
        public string reportId;
        public string playerId;
        public bool used;
        public bool reRollInjury;

        public PilingOn() : base("pilingOn") { }
    }
}
