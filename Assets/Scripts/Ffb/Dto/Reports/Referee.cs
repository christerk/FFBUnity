namespace Fumbbl.Ffb.Dto.Reports
{
    public class Referee : Report
    {
        public Referee() : base("referee") { }

        public string reportId;
        public bool foulingPlayerBanned;
    }
}
