
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class SwoopPlayer : Report
  {
    public SwoopPlayer(string key) : base(key) { }
    public string reportId;
    public string startCoordinate;
    public string endCoordinate;
    public string[] directionArray;
    public int[] rolls;
  }
}