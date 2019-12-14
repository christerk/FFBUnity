namespace Fumbbl.Ffb.Dto.Reports
{
    public class ReceiveChoice : Report
    {
        public string reportId;
        public string teamId;
        public bool receiveChoice;

        public ReceiveChoice() : base("receiveChoice") { }
    }
}
