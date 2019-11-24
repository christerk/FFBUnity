
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class TurnEnd : Report
  {
    public TurnEnd(string key) : base(key) { }
    public string playerIdTouchdown;
    public string[] knockoutRecoveries;
    public string[] heatExhaustions;
  }
}