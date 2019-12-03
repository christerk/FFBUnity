using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class BombOutOfBounds : LogTextGenerator<Ffb.Dto.Reports.BombOutOfBounds>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.BombOutOfBounds report)
        {
            yield return new LogRecord($"<b>Bomb scattered out of bounds.</b>");
        }
    }
}
