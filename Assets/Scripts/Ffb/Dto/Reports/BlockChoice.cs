namespace Fumbbl.Ffb.Dto.Reports
{
    public class BlockChoice : Report
    {
        public BlockChoice() : base("blockChoice") { }

        public string reportId;
        public int nrOfDice;
        public int[] blockRoll;
        public int diceIndex;
        public string blockResult;
        public string defenderId;
    }
}
