using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input) => "abcdefghijklmnopqrstuvwxyz".All(input.ToLowerInvariant().Contains);
}
