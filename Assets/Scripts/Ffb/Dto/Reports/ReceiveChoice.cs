namespace Fumbbl.Ffb.Dto.Reports
{
    public class ReceiveChoice : Report
    {
        public ReceiveChoice() : base("receiveChoice") { }

        public string reportId;
        public string teamId;
        public bool receiveChoice;
    }
}
