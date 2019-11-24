namespace Fumbbl.Ffb.Dto.Reports
{
    public class CoinThrow : Report
    {
        public CoinThrow() : base("coinThrow") { }

        public string reportId;
        public string coach;
        public bool coinThrowHeads;
        public bool coinChoiceHeads;
    }
}
