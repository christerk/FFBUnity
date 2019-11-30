using Fumbbl.Model.Types;
using UnityEngine;

namespace Fumbbl.Model.ModelChange
{
    public class TurnDataSetTurnNr : ModelUpdater<Ffb.Dto.ModelChanges.TurnDataSetTurnNr>
    {
        public TurnDataSetTurnNr() : base(typeof(Ffb.Dto.ModelChanges.TurnDataSetTurnNr)) { }

        public override void Apply(Ffb.Dto.ModelChanges.TurnDataSetTurnNr change)
        {
            if (change.modelChangeKey == "home")
            {
                FFB.Instance.Model.TurnHome = change.modelChangeValue;
            }
            else
            {
                FFB.Instance.Model.TurnAway = change.modelChangeValue;
            }
        }
    }
}
