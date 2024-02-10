public static class ReverseString
{
    public static string Reverse(string input)
    {
        var charArray = input.ToCharArray();
        for (int i = 0; i < charArray.Length / 2; i++)
        {
            (charArray[i], charArray[charArray.Length - 1 - i]) = (charArray[charArray.Length - 1 - i], charArray[i]);
        }
        return new string(charArray);
    }
}