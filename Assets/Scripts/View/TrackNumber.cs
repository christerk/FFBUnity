using TMPro;

namespace Fumbbl.View
{
    public class TrackNumber : IKeyedObject<TrackNumber>
    {
        public Fumbbl.Model.Types.Coordinate Coordinate { get; set; }
        public int Number;

        public object Key => Coordinate.X * 100 + Coordinate.Y;

        public TextMeshPro LabelObject { get; internal set; }

        public TrackNumber(Ffb.Dto.ModelChanges.TrackNumber square)
        {
            Coordinate = Model.Types.Coordinate.Create(square.coordinate);
            Number = square.number;
        }

        public void Refresh(TrackNumber square)
        {
            Coordinate = square.Coordinate;
            Number = square.Number;
        }
    }
}
