namespace Fumbbl.Ffb.Dto.Reports
{
    public class RaiseDead : Report
    {
        public RaiseDead() : base("raiseDead") { }

        public string reportId;
        public string playerId;
        public bool nurglesRot;
    }
}
