using Fumbbl.Model.Types;
using UnityEngine;

namespace Fumbbl.Model.ModelChange
{
    public class TeamResultSetScore : ModelUpdater<Ffb.Dto.ModelChanges.TeamResultSetScore>
    {
        public TeamResultSetScore() : base(typeof(Ffb.Dto.ModelChanges.TeamResultSetScore)) { }

        public override void Apply(Ffb.Dto.ModelChanges.TeamResultSetScore change)
        {
            if (change.modelChangeKey == "home")
            {
                FFB.Instance.Model.ScoreHome = change.modelChangeValue;
            }
            else
            {
                FFB.Instance.Model.ScoreAway = change.modelChangeValue;
            }
        }
    }
}
