using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public class WinningsRoll : Report
  {
    public WinningsRoll() : base("winningsRoll") { }
    public string reportId;
    public int winningsRollHome;
    public int winningsHome;
    public int winningsRollAway;
    public int winningsAway;
  }
}
