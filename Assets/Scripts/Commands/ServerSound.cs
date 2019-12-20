using Fumbbl.Ffb.Dto.Reports;

namespace Fumbbl.Commands
{
    public class ServerSound : CommandHandler<Ffb.Dto.Commands.ServerSound>
    {
        public override void Apply(Ffb.Dto.Commands.ServerSound command)
        {
            FFB.Instance.PlaySound(command.sound);
        }
    }
}
