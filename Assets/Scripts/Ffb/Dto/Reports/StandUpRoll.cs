
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class StandUpRoll : Report
  {
    public StandUpRoll() : base("standUpRoll") { }
    public string reportId;
    public string playerId;
    public bool successful;
    public int roll;
    public int modifier;
    public bool reRolled;
  }
}