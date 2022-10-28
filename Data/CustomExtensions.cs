#nullable enable
using System.Diagnostics.CodeAnalysis;

namespace CustomExtensions
{
    public static class CustomExtensions
    {
        public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this T[]? array) =>
            array == null || array.Length == 0;
    }
}