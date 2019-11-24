
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class TimeoutEnforced : Report
  {
    public TimeoutEnforced(string key) : base(key) { }
    public string coach;
    public string reportId;
  }
}