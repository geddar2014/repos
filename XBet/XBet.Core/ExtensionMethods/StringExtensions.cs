using System.Collections.Generic;

namespace XBet.Core.ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string self)
        {
            return string.IsNullOrEmpty(self);
        }

        public static string StringJoin(this IEnumerable<string> self, char separator)
        {
            return string.Join(separator, self);
        }
    }
}
