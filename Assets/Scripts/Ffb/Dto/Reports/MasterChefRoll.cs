namespace Fumbbl.Ffb.Dto.Reports
{
    public class MasterChefRoll : Report
    {
        public MasterChefRoll() : base("masterChefRoll") { }

        public string reportId;
        public string teamId;
        public int[] masterChefRoll;
        public int reRollsStolen;
    }
}
