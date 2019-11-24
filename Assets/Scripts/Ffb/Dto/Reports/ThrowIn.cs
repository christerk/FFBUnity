
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class ThrowIn : Report
  {
    public ThrowIn(string key) : base(key) { }
    public string reportId;
    public string direction;
    public string directionRoll;
    public string distanceRoll;
  }
}