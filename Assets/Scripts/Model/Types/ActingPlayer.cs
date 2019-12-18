namespace Fumbbl.Model.Types
{
    public class ActingPlayer
    {
        public ActionType CurrentAction { get; internal set; }
        public int CurrentMove { get; set; }
        public string PlayerId;

        public enum ActionType
        {
            Block,
            Blitz,
        }

        internal void Clear()
        {
            PlayerId = null;
        }
    }
}
