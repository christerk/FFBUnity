
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class StartHalf : Report
  {
    public StartHalf() : base("startHalf") { }
    public string reportId;
    public string half;
  }
}