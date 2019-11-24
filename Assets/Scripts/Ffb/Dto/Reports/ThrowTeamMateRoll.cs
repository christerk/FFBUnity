
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class ThrowTeamMateRoll : SkillRoll
  {
    public ThrowTeamMateRoll() : base("throwTeamMateRoll") { }
    public string thrownPlayerId;
    public string passingDistance;
  }
}