namespace Fumbbl.Ffb.Dto.Reports
{
    public class Inducement : Report
    {
        public Inducement() : base("inducement") { }

        public string reportId;
        public string teamId;
        public string inducementType;
        public int value;
    }
}
