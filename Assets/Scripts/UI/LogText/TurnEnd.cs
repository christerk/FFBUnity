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
            Player scorer = FFB.Instance.Model.GetPlayer(report.playerIdTouchdown);
            if (scorer != null)
            {
                yield return new LogRecord($"{scorer.FormattedName} scores a touchdown.", 1);
            }
            // TODO: unfinished
        }
    }
}