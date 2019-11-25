namespace Fumbbl.Ffb.Dto.Reports
{
    public class PilingOn : Report
    {
        public PilingOn() : base("pilingOn") { }

        public string reportId;
        public string playerId;
        public bool used;
        public bool reRollInjury;
    }
}
