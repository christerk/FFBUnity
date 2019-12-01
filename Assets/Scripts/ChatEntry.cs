using static Fumbbl.FFB;

namespace Fumbbl
{
    internal class ChatEntry
    {
        public string Coach { get; private set; }
        public ChatSource Source { get; private set; }
        public string Text { get; private set; }

        public ChatEntry(string coach, ChatSource source, string text)
        {
            Coach = coach;
            Source = source;
            Text = text;
        }
    }
}