namespace SByteDev.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>Indicates whether the specified string is null or an <see cref="F:System.String.Empty"></see> string.</summary>
        /// <param name="source">The string to test.</param>
        /// <returns>true if the <paramref name="source">value</paramref> parameter is null or an empty string (""); otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>Indicates whether a specified string is null, empty, or consists only of white-space characters.</summary>
        /// <param name="source">The string to test.</param>
        /// <returns>true if the <paramref name="source">value</paramref> parameter is null or <see cref="F:System.String.Empty"></see>, or if <paramref name="source">value</paramref> consists exclusively of white-space characters.</returns>
        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }
    }
}