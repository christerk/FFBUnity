
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class TimeoutEnforced : Report
  {
    public TimeoutEnforced() : base("timeoutEnforced") { }
    public string reportId;
    public string coach;
  }
}