using Fumbbl.Ffb.Dto;
using Fumbbl.Ffb.Dto.Reports;

namespace Fumbbl.Commands
{
    public class ServerModelSync : CommandHandler<Ffb.Dto.Commands.ServerModelSync>
    {
        public override void Apply(Ffb.Dto.Commands.ServerModelSync command)
        {
            var list = command?.modelChangeList?.modelChangeArray;
            if (list != null)
            {
                foreach (var obj in list)
                {
                    ModelChange change = FFB.Instance.ModelChangeFactory.DeserializeJson(obj, obj?["modelChangeId"]?.ToString());
                    if (change != null)
                    {
                        FFB.Instance.Model.ApplyChange(change);
                    }
                    else
                    {
                        FFB.Instance.AddReport(RawString.Create($"<b>* * * Missing DTO for ModelChange {obj?["modelChangeId"]} * * *</b>"));
                    }
                }
            }

            list = command?.reportList.reportArray;
            if (list != null)
            {
                foreach (var obj in list)
                {
                    Report report = FFB.Instance.ReportFactory.DeserializeJson(obj, obj?["reportId"]?.ToString());
                    if (report != null)
                    {
                        FFB.Instance.AddReport(report);
                    }
                    else
                    {
                        FFB.Instance.AddReport(RawString.Create($"<b>* * * Missing DTO for Report {obj?["reportId"]} * * *</b>"));
                    }
                }
            }

            var sound = command?.sound.key;
            if (!string.IsNullOrEmpty(sound))
            {
                FFB.Instance.PlaySound(sound);
            }
        }
    }
}
