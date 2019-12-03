namespace Fumbbl.View
{
    public class PushbackSquare : ViewObject<PushbackSquare>
    {
        public Fumbbl.Model.Types.Coordinate Coordinate { get; set; }
        public string Direction;
        public bool HomeChoice;
        public bool Locked;
        public bool Selected;

        public override object Key => Coordinate.X * 100 + Coordinate.Y;

        public PushbackSquare(Ffb.Dto.ModelChanges.PushbackSquare square)
        {
            Coordinate = new Fumbbl.Model.Types.Coordinate(square.coordinate);
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
