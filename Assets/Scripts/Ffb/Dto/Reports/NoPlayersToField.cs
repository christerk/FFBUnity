namespace Fumbbl.Ffb.Dto.Reports
{
    public class NoPlayersToField : Report
    {
        public NoPlayersToField() : base("noPlayersToField") { }

        public string reportId;
        public string teamId;
    }
}
