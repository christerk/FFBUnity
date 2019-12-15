using Fumbbl;
using Fumbbl.Model;
using Fumbbl.Model.RollModifier;
using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class PassRoll : LogTextGenerator<Ffb.Dto.Reports.PassRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.PassRoll report)
        {
            Player thrower = FFB.Instance.Model.GetPlayer(report.playerId);
            Player catcher = null;
            string obj = report.bomb? "bomb" : "ball";
            string neededRoll = "";

            // Make the passingDistance the first modifier and the reported ones follow it.
            IEnumerable<PassModifier> rollModifiers1 = report.passingDistance.As<PassModifier>().Yield();
            IEnumerable<PassModifier> rollModifiers2 = report.rollModifiers?.Select(r => r.As<PassModifier>()) ?? Enumerable.Empty<PassModifier>();
            IEnumerable<PassModifier> rollModifiers = rollModifiers1.Concat(rollModifiers2);

            if (!report.reRolled)
            {
                catcher = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.PassCoordinate);


                if (report.hailMaryPass)
                {
                    if (report.bomb)
                    {
                        yield return new LogRecord($"{thrower.FormattedName} throws a Hail Mary bomb:");
                    }
                    else
                    {
                        yield return new LogRecord($"{thrower.FormattedName} throws a Hail Mary pass:");
                    }
                }
                else if (catcher != null)
                {
                    if (report.bomb)
                    {
                        yield return new LogRecord($"{thrower.FormattedName} throws a {obj} at {catcher.FormattedName}:");
                    }
                    else
                    {
                        yield return new LogRecord($"{thrower.FormattedName} passes the {obj} to {catcher.FormattedName}:");
                    }
                }
                else
                {
                    if (report.bomb)
                    {
                        yield return new LogRecord($"{thrower.FormattedName} throws a {obj} to an empty field:");
                    }
                    else
                    {
                        yield return new LogRecord($"{thrower.FormattedName} passes the {obj} to an empty field:");
                    }
                }
                if (rollModifiers != null && rollModifiers.Contains(PassModifier.NervesOfSteel))
                {
                    if (report.bomb)
                    {
                        yield return new LogRecord($"{thrower.FormattedName} is using Nerves of Steel to throw the {obj}.");
                    }
                    else
                    {
                        yield return new LogRecord($"{thrower.FormattedName} is using Nerves of Steel to pass the {obj}.");
                    }

                }
            }

            yield return new LogRecord($"<b>Pass Roll [ {report.roll} ]</b>", 1);

            if (report.successful)
            {
                if (report.bomb)
                {
                    yield return new LogRecord($"{thrower.FormattedName} throws the {obj} successfully.", 2);
                }
                else
                {
                    yield return new LogRecord($"{thrower.FormattedName} passes the {obj}.");
                }

                if (!report.reRolled)
                {
                    neededRoll = $"Succeeded on a roll of {report.minimumRoll}+";
                }
            }
            else
            {
                if (report.safeThrowHold)
                {
                    yield return new LogRecord($"{thrower.FormattedName} holds on to the {obj}.", 2);
                }
                else if (report.fumble)
                {
                    yield return new LogRecord($"{thrower.FormattedName} fumbles the {obj}.", 2);
                }
                else
                {
                    yield return new LogRecord($"{thrower.FormattedName} misses the throw.", 2);
                }
                if (!report.reRolled)
                {
                    neededRoll = $"Roll a {report.minimumRoll}+  to succeed";
                }
            }

            if (!string.IsNullOrEmpty(neededRoll))
            {
                neededRoll += $" (AG {Math.Min(6, thrower.Agility)}";

                if (rollModifiers != null)
                {
                    neededRoll += string.Join("", rollModifiers.Select(m => m.ModifierString));
                }

                neededRoll += " + Roll > 6).";

                yield return new LogRecord(neededRoll, 2);
            }
        }
    }
}
