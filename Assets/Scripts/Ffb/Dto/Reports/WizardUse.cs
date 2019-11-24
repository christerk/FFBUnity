using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class WizardUse : Report
  {
    public WizardUse() : base("wizardUse") { }
    public string reportId;
    public string teamId;
    public string specialEffect;
  }
}
