using Fumbbl.Ffb.Dto.Reports;

namespace Fumbbl.Commands
{
    public class ServerVersion : CommandHandler<Ffb.Dto.Commands.ServerVersion>
    {
        public override void Apply(Ffb.Dto.Commands.ServerVersion command)
        {
            FFB.Instance.AddReport(RawString.Create($"Connected - Server version {command.serverVersion}"));
            FFB.Instance.Network.Spectate(FFB.Instance.GameId);
        }
    }
}
