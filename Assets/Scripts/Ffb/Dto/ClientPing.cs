namespace Fumbbl.Ffb.Dto
{
    public class ClientPing : AbstractCommand
    {
        public ClientPing() : base("clientPing") { }

        public long timestamp;
    }
}
