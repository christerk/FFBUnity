
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class SkillUse : Report
  {
    public SkillUse(string key) : base(key) { }
    public string playerId;
    public string skill;
    public bool used;
    public string skillUse;
  }
}