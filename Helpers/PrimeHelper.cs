using System.Collections.Generic;
public static class PrimeHelper
{
    public static long LargestPrimeFactor(long target)
    {
        if (target < 2)
        {
            return target;
        }
        long largestFactor = 2;
        bool foundFactor = true;
        while (foundFactor)
        {
            foundFactor = false;
            for (long i = largestFactor; i <= target / 2; i++)
            {
                if (target % i == 0)
                {
                    foundFactor = true;
                    target /= i;
                    if (i > largestFactor)
                    {
                        largestFactor = i;
                    }
                    break;
                }
            }
        }
        if (target > largestFactor)
        {
            largestFactor = target;
        }
        return largestFactor;
    }
    public static List<long> primeFactorize(long target)
    {
        List<long> primeFactors = new List<long>();
        bool foundFactor = true;
        while (foundFactor)
        {
            foundFactor = false;
            for (long i = 2; i < target / 2; i++)
            {
                if (target % i == 0)
                {
                    foundFactor = true;
                    target /= i;
                    primeFactors.Add(i);
                    break;
                }
            }
        }
        primeFactors.Add(target);
        return primeFactors;
    }
    public static bool isPrime(int target)
    {
        if (target <= 1)
        {
            return false;
        }
        for (int i = 2; i <= target / 2; i++)
        {
            if (target % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}