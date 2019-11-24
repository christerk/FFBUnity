
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class ThrowTeamMateRoll : Report
  {
    public ThrowTeamMateRoll(string key) : base(key) { }
    public string thrownPlayerId;
    public string passingDistance;
  }
}