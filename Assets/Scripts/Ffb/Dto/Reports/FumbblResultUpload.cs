namespace Fumbbl.Ffb.Dto.Reports
{
    public class FumbblResultUpload : Report
    {
        public string reportId;
        public bool successful;
        public string uploadStatus;

        public FumbblResultUpload() : base("fumbblResultUpload") { }
    }
}
