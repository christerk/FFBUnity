using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class WizardUse : Report
  {
    public WizardUse(string key) : base(key) { }
    public string teamId;
    public string specialEffect;
  }
}
