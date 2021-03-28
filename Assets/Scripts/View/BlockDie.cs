namespace Fumbbl.View
{
    public class BlockDie : IKeyedObject<BlockDie>
    {
        public int Index;
        public Model.Types.BlockDie Roll;
        public bool Active;

        public object Key => Index;

        public BlockDie(int index, Model.Types.BlockDie roll)
        {
            Index = index;
            Roll = roll;
            Active = true;
        }

        public void Set(BlockDie data)
        {
            Index = data.Index;
            Roll = data.Roll;
            Active = true;
        }

        public void Unset()
        {
            Active = false;
        }
    }
}
