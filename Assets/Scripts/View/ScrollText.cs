using Fumbbl.Model.Types;

namespace Fumbbl.View
{
    public class ScrollText : IKeyedObject<ScrollText>
    {
        public Player Player;
        public string Text;
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
    }
}
