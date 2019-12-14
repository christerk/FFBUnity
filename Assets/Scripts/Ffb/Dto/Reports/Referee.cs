namespace Fumbbl.Ffb.Dto.Reports
{
    public class Referee : Report
    {
        public string reportId;
        public bool foulingPlayerBanned;

        public Referee() : base("referee") { }
    }
}
