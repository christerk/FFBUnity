using Fumbbl.Ffb.Dto.Reports;

namespace Fumbbl.Commands
{
    public class ServerTalk : CommandHandler<Ffb.Dto.Commands.ServerTalk>
    {
        public override void Apply(Ffb.Dto.Commands.ServerTalk command)
        {
            foreach (var talk in command.talks)
            {
                FFB.Instance.AddChatEntry(command.coach, talk);
            }
        }
    }
}
