using System;
public static class MathHelper
{
    public static double Clamp(double value, double min, double max)
    {
        if (min > max)
        {
            throw new ArgumentException();
        }
        if (value > max)
        {
            return max;
        }
        else if (value < min)
        {
            return min;
        }
        else
        {
            return value;
        }
    }
    public static double LoopClamp(double value, double min, double max)
    {
        if (min > max)
        {
            throw new ArgumentException();
        }
        int loopCount = (int)((value - min) / (max - min));
        return value - (loopCount * (max - min));
    }
    public static double Abs(double value)
    {
        if (value < 0)
        {
            return value * -1;
        }
        else
        {
            return value;
        }
    }

    public static double Cos(double input)
    {
        return Math.Cos(input);
    }

    internal static double Sin(double input)
    {
        return Math.Sin(input);
    }

    public static double Min(double a, double b)
    {
        if (a < b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
    public static double Max(double a, double b)
    {
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
    public static double Sqrt(double value)
    {
        return Math.Sqrt(value);
    }
    public static double Lerp(double sample, double a, double b)
    {
        return a + ((b - a) * sample);
    }
    public static double InverseLerp(double sample, double a, double b)
    {
        return (sample - a) / (b - a);
    }

    public static double Atan(double input)
    {
        return Math.Atan(input);
    }
}