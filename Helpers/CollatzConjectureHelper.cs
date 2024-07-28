using System.Collections.Generic;

namespace MathPuzzles
{
    public static class CollatzConjectureHelper
    {
        public static List<long> Calculate(long source)
        {
            List<long> output = new List<long>();
            while (source != 1)
            {
                output.Add(source);
                if (source % 2 == 0)
                {
                    source = source / 2;
                }
                else
                {
                    source = source * 3;
                    source = source + 1;
                }
            }
            return output;
        }
    }
}
