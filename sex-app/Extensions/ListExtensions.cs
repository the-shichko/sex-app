using System.Collections.Generic;

namespace sex_app.Extensions
{
    public static class ListExtensions
    {
        public static string Join(this IEnumerable<string> sourceList, string separator)
        {
            return string.Join(separator, sourceList);
        }
    }
}