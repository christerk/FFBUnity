
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public class Spectators : Report
  {
    public Spectators() : base("spectators") { }
    public int[] spectatorRollHome;
    public int spectatorsHome;
    public int fameHome;
    public int[] spectatorRollAway;
    public int spectatorsAway;
    public int fameAway;
  }
}