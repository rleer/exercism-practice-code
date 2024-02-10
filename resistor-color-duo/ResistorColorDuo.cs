using System;

public static class ResistorColorDuo
{
    
    public static int ColorCode(string color) => Array.IndexOf(Colors(), color);

    public static string[] Colors() => new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };

    public static int Value(string[] colors) => ColorCode(colors[0]) * 10 + ColorCode(colors[1]);
}
