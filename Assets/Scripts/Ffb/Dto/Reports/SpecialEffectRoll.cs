
using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
  public abstract class SpecialEffectRoll : Report
  {
    public SpecialEffectRoll(string key) : base(key) { }
    public string specialEffect;
    public string playerId;
    public int roll;
    public bool successful;
  }
}