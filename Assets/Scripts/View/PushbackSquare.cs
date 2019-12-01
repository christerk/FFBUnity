namespace Fumbbl.View
{
    public class PushbackSquare : ViewObject<PushbackSquare>
    {
        public int[] Coordinate;
        public string Direction;
        public bool HomeChoice;
        public bool Locked;
        public bool Selected;

        public override object Key => Coordinate[0] * 100 + Coordinate[1];

        public PushbackSquare(Ffb.Dto.ModelChanges.PushbackSquare square)
        {
            Coordinate = square.coordinate;
            Direction = square.direction.key;
            HomeChoice = square.homeChoice;
            Locked = square.locked;
            Selected = square.selected;
        }

        public override void Refresh(PushbackSquare square)
        {
            Coordinate = square.Coordinate;
            Direction = square.Direction;
            HomeChoice = square.HomeChoice;
            Locked = square.Locked;
            Selected = square.Selected;
        }
    }
}
