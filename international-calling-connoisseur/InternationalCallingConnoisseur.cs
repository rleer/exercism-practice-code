using System;
using System.Collections.Generic;
using System.Linq;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary() => new();

    public static Dictionary<int, string> GetExistingDictionary() => new() { { 1, "United States of America" }, { 55, "Brazil" }, { 91, "India" } };

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName) => new() { { countryCode, countryName } };

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName) => existingDictionary
        .Append(new KeyValuePair<int, string>(countryCode, countryName)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode) =>
        existingDictionary.ContainsKey(countryCode) ? existingDictionary[countryCode] : string.Empty;

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode) => existingDictionary.ContainsKey(countryCode);

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (existingDictionary.ContainsKey(countryCode)) existingDictionary[countryCode] = countryName;
        return existingDictionary;
    }


    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        (string country, int length) longestCountryNamePair = (string.Empty, 0);
        foreach (var kvp in existingDictionary)
        {
            if (kvp.Value.Length > longestCountryNamePair.length)
                longestCountryNamePair = (kvp.Value, kvp.Value
                    .Length);
        }

        return longestCountryNamePair.country;
    }
}