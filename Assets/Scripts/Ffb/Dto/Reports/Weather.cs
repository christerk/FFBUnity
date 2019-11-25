
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public class Weather : Report
  {
    public Weather() : base("weather") { }
    public string reportId;
    public string weather;
    public int[] weatherRoll;
  }
}