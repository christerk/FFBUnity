
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class Spectators : Report
  {
    public Spectators(string key) : base(key) { }
    public int[] spectatorRollHome;
    public int spectatorsHome;
    public int fameHome;
    public int[] spectatorRollAway;
    public int spectatorsAway;
    public int fameAway;
  }
}