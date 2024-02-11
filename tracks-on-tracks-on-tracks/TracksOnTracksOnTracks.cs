using System.Collections.Generic;
using System.Linq;

public static class Languages
{
    public static List<string> NewList() => new();

    public static List<string> GetExistingLanguages() => new() { "C#", "Clojure", "Elm" };

    public static List<string> AddLanguage(List<string> languages, string language) => languages.Append(language).ToList();

    public static int CountLanguages(List<string> languages) => languages.Count;

    public static bool HasLanguage(List<string> languages, string language) => languages.Contains(language);

    public static List<string> ReverseList(List<string> languages) => languages.Reverse<string>().ToList();

    public static bool IsExciting(List<string> languages) => languages.Count > 0 && 
                                                             (languages[0] == "C#" || 
                                                             (languages[1] == "C#" && languages.Count is 2 or 3));

    public static List<string> RemoveLanguage(List<string> languages, string language) => languages.Where(l => l != language).ToList();

    public static bool IsUnique(List<string> languages) => languages.Distinct().Count() == languages.Count;
}
