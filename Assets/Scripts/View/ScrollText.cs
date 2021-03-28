using Fumbbl.Model.Types;

namespace Fumbbl.View
{
    public class ScrollText : IKeyedObject<ScrollText>
    {
        public Player Player;
        public string Text;
        public bool Active;

        public object Key => Player.Id;

        public ScrollText(Player player, string text)
        {
            Player = player;
            Text = text;
        }

        public void Refresh(ScrollText data)
        {
            Player = data.Player;
            Text = data.Text;
        }

        public void Set(ScrollText o)
        {
            Player = o.Player;
            Text = o.Text;
            Active = true;
        }

        public void Unset()
        {
            Active = false;
        }
    }
}
