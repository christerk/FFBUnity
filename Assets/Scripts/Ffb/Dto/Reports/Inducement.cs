namespace Fumbbl.Ffb.Dto.Reports
{
    public class Inducement : Report
    {
        public string reportId;
        public string teamId;
        public string inducementType;
        public int value;

        public Inducement() : base("inducement") { }
    }
}
