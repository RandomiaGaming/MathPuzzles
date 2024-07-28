using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPuzzles
{
    public static class AmicablePairHelper
    {
        public static List<long> GetProperDivisors(long source)
        {
            List<long> output = new List<long>();
            for (long i = 1; i < source; i++)
            {
                if (source % i == 0)
                {
                    output.Add(i);
                }
            }
             return output;
        }
        public static long GetAmicableSum(long source)
        {
            List<long> properDivisors = GetProperDivisors(source);
            long output = 0;
            foreach (long properDivisor in properDivisors)
            {
                output += properDivisor;
            }
            return output;
        }
    }
}
