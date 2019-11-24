
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class SkillUse : Report
  {
    public SkillUse() : base("skillUse") { }
    public string reportId;
    public string playerId;
    public string skill;
    public bool used;
    public string skillUse;
  }
}