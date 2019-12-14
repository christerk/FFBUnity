namespace Fumbbl.Ffb.Dto.Reports
{
    public class RaiseDead : Report
    {
        public string reportId;
        public string playerId;
        public bool nurglesRot;

        public RaiseDead() : base("raiseDead") { }
    }
}
