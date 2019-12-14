namespace Fumbbl.Ffb.Dto.Reports
{
    public class MasterChefRoll : Report
    {
        public string reportId;
        public string teamId;
        public int[] masterChefRoll;
        public int reRollsStolen;

        public MasterChefRoll() : base("masterChefRoll") { }
    }
}
