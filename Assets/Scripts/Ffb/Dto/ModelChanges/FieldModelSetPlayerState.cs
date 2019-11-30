
namespace Fumbbl.Ffb.Dto.ModelChanges
{
    public class FieldModelSetPlayerState : ModelChange
    {
        public string modelChangeId;
        public string modelChangeKey;
        public int? modelChangeValue;

        public FieldModelSetPlayerState() : base("fieldModelSetPlayerState")
        {
        }
    }
}
