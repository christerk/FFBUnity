
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public class TentaclesShadowingRoll : Report
  {
    public TentaclesShadowingRoll() : base("tentaclesShadowingRoll") { }
    public string reportId;
    public string skill;
    public string defenderId;
    public int[] tentacleRoll;
    public bool sucessful;
    public int minimumRoll;
    public bool reRolled;
  }
}