namespace Fumbbl.UI
{
    public class LogRecord
    {
        public string Text { get; }
        public int Indent { get; }

        public LogRecord(string text) : this(text, 0) { }

        public LogRecord(string text, int indent)
        {
            Text = text;
            Indent = indent;
        }
    }
}
