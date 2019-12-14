namespace Fumbbl.Ffb.Dto.Reports
{
    public class NoPlayersToField : Report
    {
        public string reportId;
        public string teamId;

        public NoPlayersToField() : base("noPlayersToField") { }
    }
}
