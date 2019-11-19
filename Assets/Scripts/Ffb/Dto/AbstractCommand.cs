namespace Fumbbl.Dto
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
