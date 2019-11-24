namespace Fumbbl.Ffb.Dto.Reports
{
    public class PlayCard : Report
    {
        public PlayCard() : base("playCard") { }

        public string reportId;
        public string teamId;
        public string card;
        public string playerId;
    }
}
