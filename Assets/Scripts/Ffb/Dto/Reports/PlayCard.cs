namespace Fumbbl.Ffb.Dto.Reports
{
    public class PlayCard : Report
    {
        public string reportId;
        public string teamId;
        public string card;
        public string playerId;

        public PlayCard() : base("playCard") { }
    }
}
