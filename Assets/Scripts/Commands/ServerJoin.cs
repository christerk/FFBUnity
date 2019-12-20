using Fumbbl.Ffb.Dto.Reports;

namespace Fumbbl.Commands
{
    public class ServerJoin : CommandHandler<Ffb.Dto.Commands.ServerJoin>
    {
        public override void Apply(Ffb.Dto.Commands.ServerJoin command)
        {
            FFB.Instance.AddReport(RawString.Create($"{command.clientMode} {command.coach} joins the game"));
        }
    }
}
