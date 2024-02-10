using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey) =>
        new(text.Select(c =>
        {
            if (!char.IsLetter(c)) return c;
            var b = char.IsLower(c) ? 'a' : 'A';
            return (char)(((c - b + shiftKey) % 26) + b);
        }).ToArray());
}