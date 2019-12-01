using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
