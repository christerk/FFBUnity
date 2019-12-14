namespace Fumbbl.Ffb.Dto
{
    public class ClientPing : AbstractCommand
    {
        public long timestamp;

        public ClientPing() : base("clientPing") { }
    }
}
