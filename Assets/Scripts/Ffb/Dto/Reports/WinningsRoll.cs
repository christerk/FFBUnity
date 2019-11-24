using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class WinningsRoll : Report
  {
    public WinningsRoll(string key) : base(key) { }
    public int winningsRollHome;
    public int winningsHome;
    public int winningsRollAway;
    public int winningsAway;
  }
}
