using System;
using System.Text;

public static class Identifier
{
    private static bool IsGreekLowercase(char c) => char.IsBetween(c, 'α', 'ω');
    
    public static string Clean(string identifier)
    {
        var sb = new StringBuilder();
        var isAfterDash = false;

        foreach (char c in identifier)
        {
            sb.Append(c switch
            {
                _ when IsGreekLowercase(c) => string.Empty,
                _ when isAfterDash => char.ToUpperInvariant(c),
                _ when char.IsControl(c) => "CTRL",
                _ when char.IsWhiteSpace(c) => '_',
                _ when char.IsLetter(c) => c,
                _ => string.Empty,
            });

            isAfterDash = c.Equals('-');
        }
        return sb.ToString();
    }
}
