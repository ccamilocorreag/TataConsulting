using System.Text.RegularExpressions;

namespace Core.TextAnalyzer.Entities
{
    public class TextComplete
    {
        public TextComplete()
        {
        }

        public TextComplete(string text, string word)
        {
            Text = text;
            Word = word;
        }

        private string Text { get; }
        private string Word { get; }

        public int GetNumberTimesWordInText()
        {
            return Regex.Matches(Text, Word).Count;
        }
    }
}