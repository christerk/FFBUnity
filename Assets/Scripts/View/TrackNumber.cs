using TMPro;

namespace Fumbbl.View
{
    public class TrackNumber : ViewObject<TrackNumber>
    {
        public int[] Coordinate;
        public int Number;

        public override object Key => Coordinate[0] * 100 + Coordinate[1];

        public TextMeshPro LabelObject { get; internal set; }

        public TrackNumber(Ffb.Dto.ModelChanges.TrackNumber square)
        {
            Coordinate = square.coordinate;
            Number = square.number;
        }

        public override void Refresh(TrackNumber square)
        {
            Coordinate = square.Coordinate;
            Number = square.Number;
        }
    }
}
