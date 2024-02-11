using System.Collections.Generic;

public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        if (number == 1) return new long[] { };
        var divisor = 2;
        var primeFactors = new List<long>();
        while (number > 1)
        {
            if (number % divisor == 0)
            {
                number /= divisor;
                primeFactors.Add(divisor);
            }
            else
            {
                divisor++;
            }
        }
        return primeFactors.ToArray();
    }
}