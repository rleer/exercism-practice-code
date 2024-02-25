using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            return checked($"{@base * multiplier}");
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        var dom = multiplier * @base;
        return float.IsInfinity(dom) ? "*** Too Big ***" : $"{dom}";
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            return checked($"{salaryBase * multiplier}");
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }
    }
}
