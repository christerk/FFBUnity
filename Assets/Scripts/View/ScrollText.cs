using Fumbbl.Model.Types;

namespace Fumbbl.View
{
    public class ScrollText : ViewObject<ScrollText>
    {
        public Player Player;
        public string Text;
        public override object Key => Player.Id;

        public ScrollText(Player player, string text)
        {
            Player = player;
            Text = text;
        }

        public override void Refresh(ScrollText data)
        {
            Player = data.Player;
            Text = data.Text;
        }
    }
}
