namespace Fumbbl.Ffb.Dto
{
    public class ClientTalk : AbstractCommand
    {
        public ClientTalk() : base("clientTalk") { }

        public string talk;
    }
}
