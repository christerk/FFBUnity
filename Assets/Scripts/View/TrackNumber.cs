using TMPro;

namespace Fumbbl.View
{
    public class TrackNumber : ViewObject<TrackNumber>
    {
        public Fumbbl.Model.Types.Coordinate Coordinate { get; set; }
        public int Number;

        public override object Key => Coordinate.X * 100 + Coordinate.Y;

        public TextMeshPro LabelObject { get; internal set; }

        public TrackNumber(Ffb.Dto.ModelChanges.TrackNumber square)
        {
            Coordinate = Model.Types.Coordinate.Create(square.coordinate);
            Number = square.number;
        }

        public override void Refresh(TrackNumber square)
        {
            Coordinate = square.Coordinate;
            Number = square.Number;
        }
    }
}
