namespace Fumbbl.Ffb.Dto.Reports
{
    public class FumbblResultUpload : Report
    {
        public FumbblResultUpload() : base("fumbblResultUpload") { }

        public string reportId;
        public bool successful;
        public string uploadStatus;
    }
}
