namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerModelSync : NetCommand
    {
        public string netCommandId;
        public int commandNr;
        public ModelChangeList modelChangeList;
        public ReportList reportList;
        public Animation animation;
        public FFBEnumeration sound;
        public long gameTime;
        public long turnTime;

        public ServerModelSync() : base("serverModelSync") { }
    }
}
