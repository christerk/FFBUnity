namespace Fumbbl.Ffb.Dto
{
    public class ClientTalk : AbstractCommand
    {
        public string talk;

        public ClientTalk() : base("clientTalk") { }
    }
}
