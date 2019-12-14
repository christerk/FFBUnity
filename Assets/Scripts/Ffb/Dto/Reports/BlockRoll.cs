namespace Fumbbl.Ffb.Dto.Reports
{
    public class BlockRoll : Report
    {
        public string reportId;
        public string choosingTeamId;
        public int[] blockRoll;

        public BlockRoll() : base("blockRoll") { }
    }
}
