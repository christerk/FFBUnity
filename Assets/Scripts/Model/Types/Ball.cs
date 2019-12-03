namespace Fumbbl.Model.Types
{
    public class Ball
    {
        public Coordinate Coordinate { get; set; }
        public bool InPlay { get; set; }
        public bool Moving { get; set; }

        public Ball()
        {
            Coordinate = new Coordinate(0, 0);
        }
    }
}