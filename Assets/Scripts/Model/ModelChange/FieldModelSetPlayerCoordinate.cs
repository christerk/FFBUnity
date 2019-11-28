using Fumbbl.Model.Types;
using UnityEngine;

namespace Fumbbl.Model.ModelChange
{
    public class FieldModelSetPlayerCoordinate : ModelUpdater
    {
        public FieldModelSetPlayerCoordinate() : base(typeof(Ffb.Dto.ModelChanges.FieldModelSetPlayerCoordinate)) { }

        public override void Apply(Ffb.Dto.ModelChange modelChange)
        {
            var change = (Ffb.Dto.ModelChanges.FieldModelSetPlayerCoordinate)modelChange;

            Player p = FFB.Instance.Model.GetPlayer(change.modelChangeKey);

            p.Coordinate = change.modelChangeValue;
        }
    }
}
