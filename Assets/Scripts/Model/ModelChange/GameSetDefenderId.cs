using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fumbbl.Ffb.Dto.ModelChanges;

namespace Fumbbl.Model.ModelChange
{
    public class GameSetDefenderId : ModelUpdater<Ffb.Dto.ModelChanges.GameSetDefenderId>
    {
        public GameSetDefenderId() : base(typeof(Ffb.Dto.ModelChanges.GameSetDefenderId)) { }
        public override void Apply(Ffb.Dto.ModelChanges.GameSetDefenderId change)
        {
            FFB.Instance.Model.DefenderId = change.modelChangeKey;
        }
    }
}
