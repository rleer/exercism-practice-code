using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word) => word.ToLowerInvariant()
        .Where(char.IsLetter)
        .GroupBy(letter => letter)
        .All(ltrg => ltrg.Count() == 1);
}