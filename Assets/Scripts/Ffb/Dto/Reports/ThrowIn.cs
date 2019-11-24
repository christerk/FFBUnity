
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class ThrowIn : Report
  {
    public ThrowIn() : base("throwIn") { }
    public string reportId;
    public string direction;
    public int directionRoll;
    public int[] distanceRoll;
  }
}