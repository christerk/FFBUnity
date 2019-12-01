namespace Fumbbl.Model.Types
{
    public class Team
    {
        public Coach Coach { get; internal set; }

        public bool IsHome => Coach.IsHome;

        public string Id { get; internal set; }
        public int Fame { get; internal set; }

        public Team()
        {
            Coach = new Coach();
        }
    }
}
