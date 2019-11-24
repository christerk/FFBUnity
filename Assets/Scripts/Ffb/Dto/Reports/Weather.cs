
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class Weather : Report
  {
    public Weather(string key) : base(key) { }
    public string reportId;
    public string weather;
    public int[] weatherRoll;
  }
}