namespace Dogs.Infrastructure.Extensions;

/// <summary>
///     String extensions
/// </summary>
public static class StringExtensions
{
    /// <summary>
    ///     Capitalizes the first letter of the string
    /// </summary>
    /// <param name="input">Input string should be transformed</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Input string is null</exception>
    /// <exception cref="ArgumentException">Input string is empty</exception>
    public static string FirstCharToUpper(this string input)
    {
        return input is not null ? string.Concat(input.First().ToString().ToUpper(), input.AsSpan(1)) : null;
    }
}