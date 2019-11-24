
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class TurnEnd : Report
  {
    public TurnEnd() : base("turnEnd") { }
    public string reportId;
    public string playerIdTouchdown;
    public string[] knockoutRecoveries;
    public string[] heatExhaustions;
  }
}