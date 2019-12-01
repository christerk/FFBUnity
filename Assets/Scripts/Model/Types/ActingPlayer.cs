namespace Fumbbl.Model.Types
{
    public class ActingPlayer
    {
        public string PlayerId;
        public ActionType CurrentAction { get; internal set; }

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