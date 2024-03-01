using System.Globalization;

namespace Shop
{
    public static class StringExtensions
    {
        private static TextInfo _textInfo = CultureInfo.CurrentCulture.TextInfo;

        public static string ToTitleCase(this string text)
        {
            if (text != null)
            {
                return _textInfo.ToTitleCase(text);
            }

            return string.Empty;
        }
    }
}