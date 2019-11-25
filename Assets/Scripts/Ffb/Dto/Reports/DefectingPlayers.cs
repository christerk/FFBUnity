namespace Fumbbl.Ffb.Dto.Reports
{
    public class DefectingPlayers : Report
    {
        public DefectingPlayers() : base("defectingPlayers") { }

        public string reportId;
        public string[] playerIds;
        public int[] rolls;
        public bool[] defecingArray;
    }
}
