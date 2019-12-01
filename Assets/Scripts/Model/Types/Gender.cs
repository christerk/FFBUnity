namespace Fumbbl.Model.Types
{
    public class Gender
    {
        public string Genetive { get; private set; }
        public string Dative { get; private set; }
        public object Nominative { get; internal set; }

        public static Gender Male = new Gender()
        {
            Genetive = "his",
            Dative = "him",
            Nominative = "he"
        };

    }
}
