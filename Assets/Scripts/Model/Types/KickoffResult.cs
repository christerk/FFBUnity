namespace Fumbbl.Model.Types
{
    public class KickoffResult : FfbEnumerationFactory
    {
        public string Title;
        public string Description;

        public KickoffResult(string name) : base(name) { }

        public static KickoffResult GetTheRef = new KickoffResult("Get the Ref") { Title = "Get the Ref", Description = "Each coach receives a free bribe." };
        public static KickoffResult Riot = new KickoffResult("Riot") { Title = "Riot", Description = "The referee adjusts the clock after the riot clears." };
        public static KickoffResult PerfectDefence = new KickoffResult("Perfect Defence") { Title = "Perfect Defence", Description = "The kicking team may reorganize its players." };
        public static KickoffResult HighKick = new KickoffResult("High Kick") { Title = "High Kick", Description = "A player on the receiving team may try to catch the ball directly." };
        public static KickoffResult CheeringFans = new KickoffResult("Cheering Fans") { Title = "Cheering Fans", Description = "The team with the most enthusiastic fans gains a re-roll." };
        public static KickoffResult WeatherChange = new KickoffResult("Weather Change") { Title = "Weather Change", Description = "The weather changes suddenly." };
        public static KickoffResult BrilliantCoaching = new KickoffResult("Brilliant Coaching") { Title = "Brilliant Coaching", Description = "The team with the best coaching gains a re-roll." };
        public static KickoffResult QuickSnap = new KickoffResult("Quick Snap") { Title = "Quick Snap!", Description = "The offence may reposition their players 1 square each." };
        public static KickoffResult Blitz = new KickoffResult("Blitz") { Title = "Blitz!", Description = "The defence receives a free turn for moving and blitzing." };
        public static KickoffResult ThrowARock = new KickoffResult("Throw a Rock") { Title = "Throw a Rock", Description = "A random player is hit by a rock and suffers an injury." };
        public static KickoffResult PitchInvasion = new KickoffResult("Pitch Invasion") { Title = "Pitch Invasion", Description = "Random players are being stunned by the crowd." };
    }
}
