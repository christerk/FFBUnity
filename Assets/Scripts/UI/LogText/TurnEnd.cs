using Fumbbl.Model;
using Fumbbl.Model.Types;
using Fumbbl.Model.RollModifier;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class TurnEnd : LogTextGenerator<Ffb.Dto.Reports.TurnEnd>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.TurnEnd report)
        {
            var colorsettings = FFB.Instance.Settings.Color;
            Player scorer = FFB.Instance.Model.GetPlayer(report.playerIdTouchdown);
            if (scorer != null)
            {
                yield return new LogRecord($"{scorer.FormattedName} scores a touchdown.", 1);
            }
            if (0 < report.knockoutRecoveryArray?.Length)
            {
                string s = String.Empty;
                foreach (Fumbbl.Ffb.Dto.Reports.KnockoutRecoveryResult res in report.knockoutRecoveryArray)
                {
                    Player player = FFB.Instance.Model.GetPlayer(res.playerId);

                    s = $"<b>Knockout Recovery Roll [ {res.roll} ]</b>";
                    if (0 < res.bloodweiserBabes)
                    {
                        s += $"<b> + {res.bloodweiserBabes} Bloodweiser Babes</b>";
                    }
                    yield return new LogRecord(s);
                    if (res.recovering)
                    {
                        yield return new LogRecord($"{player.FormattedName} is regaining consciousness.", 1);
                    }
                    else
                    {
                        yield return new LogRecord($"{player.FormattedName} stays unconscious.", 1);
                    }
                }
            }
            if (0 < report.heatExhaustionArray?.Length)
            {
                string s = String.Empty;
                foreach (Fumbbl.Ffb.Dto.Reports.HeatExhaustionResult res in report.heatExhaustionArray)
                {
                    Player player = FFB.Instance.Model.GetPlayer(res.playerId);

                    s = $"<b>Heat Exhaustion Roll [ {res.roll} ]</b>";
                    if (res.exhausted)
                    {
                        yield return new LogRecord($"{player.FormattedName} is suffering from heat exhaustion.", 1);
                    }
                    else
                    {
                        yield return new LogRecord($"{player.FormattedName} is unaffected.", 1);
                    }
                }
            }
            if (FFB.Instance.Model.TurnMode == TurnMode.Regular)
            {
                if (FFB.Instance.Model.HomePlaying)
                {
                    yield return new LogRecord($"<size=16><color={colorsettings.HomeColor}>{FFB.Instance.Model.TeamHome.Name} start turn {FFB.Instance.Model.TurnHome}.</color></size>");
                }
                else
                {
                    yield return new LogRecord($"<size=16><color={colorsettings.AwayColor}>{FFB.Instance.Model.TeamAway.Name} start turn {FFB.Instance.Model.TurnAway}.</color></size>");
                }
            }
        }
    }
}