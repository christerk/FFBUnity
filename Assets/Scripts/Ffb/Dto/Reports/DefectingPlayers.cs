namespace Fumbbl.Ffb.Dto.Reports
{
    public class DefectingPlayers : Report
    {
        public string reportId;
        public string[] playerIds;
        public int[] rolls;
        public bool[] defecingArray;

        public DefectingPlayers() : base("defectingPlayers") { }
    }
}
