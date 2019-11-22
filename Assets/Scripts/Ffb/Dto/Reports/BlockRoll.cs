namespace Fumbbl.Ffb.Dto.Reports
{
    public class BlockRoll : Report
    {
        public BlockRoll() : base("blockRoll") { }

        public string reportId;
        public string choosingTeamId;
        public int[] blockRoll;
    }
}
