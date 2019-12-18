using Fumbbl.Model.Types;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class FanFactorRoll : LogTextGenerator<Ffb.Dto.Reports.FanFactorRoll>
    {

        enum WLD { WIN, LOSE, DRAW }
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.FanFactorRoll report)
        {

            int totalHome = report.fanFactorRollHome.Sum();
            int resultHome = totalHome + report.fanFactorModifierHome;
            WLD wldHome = CalcResult(FFB.Instance.Model.ScoreHome, FFB.Instance.Model.ScoreAway);
            yield return new LogRecord($"<b>Fan Factor Roll Home Team {FanFactorRollString(report.fanFactorRollHome)}</b>");
            yield return new LogRecord($"Fan Factor {FFB.Instance.Model.TeamHome.FanFactor} Result: {totalHome} + {report.fanFactorModifierHome} = {totalHome + report.fanFactorModifierHome}", 1);
            yield return new LogRecord($"{FFB.Instance.Model.TeamHome.FormattedName} {LoseOrKeepString(wldHome, resultHome - FFB.Instance.Model.TeamHome.FanFactor)} fans", 1);

            int totalAway = report.fanFactorRollAway.Sum();
            int resultAway = totalAway + report.fanFactorModifierAway;
            WLD wldAway = CalcResult(FFB.Instance.Model.ScoreAway, FFB.Instance.Model.ScoreHome);
            yield return new LogRecord($"<b>Fan Factor Roll Away Team {FanFactorRollString(report.fanFactorRollAway)}</b>");
            yield return new LogRecord($"Fan Factor {FFB.Instance.Model.TeamAway.FanFactor} Result: {totalAway} + {report.fanFactorModifierAway} = {totalAway + report.fanFactorModifierAway}", 1);
            yield return new LogRecord($"{FFB.Instance.Model.TeamAway.FormattedName} {LoseOrKeepString(wldAway, resultAway - FFB.Instance.Model.TeamAway.FanFactor)} fans", 1);
        }

        private WLD CalcResult(int yourScore, int theirScore)
        {
            if(yourScore > theirScore) { return WLD.WIN;}
            else if(yourScore < theirScore) { return WLD.LOSE;}
            else { return WLD.DRAW;}
        }

        private string FanFactorRollString(int[] rolls)
        {
            string rollString = "[ ";
            rollString += string.Join(" ][ ", rolls);
            rollString += " ]";
            return rollString;
        }
        private string LoseOrKeepString(WLD result, int total)
        {
           if(total < 0 && result != WLD.WIN) 
           {
               return "lose some";
           }
           else if (total > 0 && result != WLD.LOSE)
           {
               return "wins some new";
           }
           else
           {
               return "keep their";
           }
        }

    }
}
