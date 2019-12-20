using Fumbbl.Ffb.Dto.Reports;

namespace Fumbbl.Commands
{
    public class ServerLeave : CommandHandler<Ffb.Dto.Commands.ServerLeave>
    {
        public override void Apply(Ffb.Dto.Commands.ServerLeave command)
        {
            FFB.Instance.AddReport(RawString.Create($"{command.clientMode} {command.coach} leaves the game"));
        }
    }
}
