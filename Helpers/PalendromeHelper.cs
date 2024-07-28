public static class PalendromeHelper
{
    public static int LargestPalendromicNumber()
    {
        int largestPalendromicNumber = int.MinValue;
        for (int x = 100; x < 999; x++)
        {
            for (int y = x; y < 999; y++)
            {
                if (x * y > largestPalendromicNumber && IsPalendromicNumber(x * y))
                {
                    largestPalendromicNumber = x * y;
                }
            }
        }
        return largestPalendromicNumber;
    }
    public static bool IsPalendromicNumber(int target)
    {
        return IsPalendrom(target.ToString());
    }
    public static bool IsPalendrom(string target)
    {
        for (int i = 0; i < target.Length / 2; i++)
        {
            if (target[i] != target[target.Length - 1 - i])
            {
                return false;
            }
        }
        return true;
    }
}