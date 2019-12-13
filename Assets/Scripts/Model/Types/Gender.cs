namespace Fumbbl.Model.Types
{
    public class Gender
    {
        public string Dative { get; private set; }
        public string Genetive { get; private set; }
        public object Nominative { get; private set; }

        public static Gender Male = new Gender()
        {
            Dative = "him",
            Genetive = "his",
            Nominative = "he"
        };

    }
}
