namespace Fumbbl.Ffb.Dto
{
    public class AbstractCommand
    {
        public string netCommandId { get; }

        public AbstractCommand(string netCommandId)
        {
            this.netCommandId = netCommandId;
        }
    }
}
