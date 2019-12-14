namespace Fumbbl.Ffb.Dto.Reports
{
    public class HandOver : Report
    {
        public string reportId;
        public string catcherId;

        public HandOver() : base("handOver") { }
    }
}
