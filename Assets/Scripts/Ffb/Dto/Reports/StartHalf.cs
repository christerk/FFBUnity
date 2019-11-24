
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class StartHalf : Report
  {
    public StartHalf(string key) : base(key) { }
    public string reportId;
    public string half;
  }
}