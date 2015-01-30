using System.Text.RegularExpressions;

namespace TweetSharp.Helpers
{
    internal class StringHelpers
    {
        private const string UnderscoresPattern = "(((?<=[a-z])[A-Z])|([A-Z](?![A-Z]|$)))";

        public static string Capitalize(string upperCase)
        {
            var lower = upperCase.ToLowerInvariant();
            return char.ToUpperInvariant(lower[0]) + lower.Substring(1);
        }
        
        public static string CamelCase(string pascalCase)
        {
            return char.ToLowerInvariant(pascalCase[0]) + pascalCase.Substring(1);
        }

        public static string PascalCase(string camelCase)
        {
            return char.ToUpperInvariant(camelCase[0]) + camelCase.Substring(1);
        }

        public static string Underscore(string camelCase)
        {
            var underscored = Regex.Replace(camelCase, UnderscoresPattern, m => string.Concat("_", m.Value.ToLowerInvariant()));
            return underscored;
        }
    }
}