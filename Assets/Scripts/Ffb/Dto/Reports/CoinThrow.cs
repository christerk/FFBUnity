namespace Fumbbl.Ffb.Dto.Reports
{
    public class CoinThrow : Report
    {
        public string reportId;
        public string coach;
        public bool coinThrowHeads;
        public bool coinChoiceHeads;

        public CoinThrow() : base("coinThrow") { }
    }
}
