namespace MathPuzzles
{
    public static class KinamaticsHelper
    {
        public const double RadToDeg = 57.295779513082323;
        public const double DegToRad = 0.017453292519943295;

        public static double Mag(double x, double y)
        {
            return System.Math.Sqrt((x * x) + (y * y));
        }
        public static double ATan2(double x, double y)
        {
            double systemReturn = System.Math.Atan2(y, x);
            if (systemReturn < 0)
            {
                systemReturn += 2 * System.Math.PI;
            }
            return systemReturn * RadToDeg;
        }
        public static void BruteForce(double desiredOutput, double min, double max, double step)
        {
            double bestInput = 0;
            double bestAccuracy = double.PositiveInfinity;

            for (double i = min; i <= max; i += step)
            {
                double ret = RunSimulation(i);
                double acc = System.Math.Abs(ret - desiredOutput);
                if (acc < bestAccuracy)
                {
                    bestAccuracy = acc;
                    bestInput = ret;
                }
            }

            System.Console.WriteLine($"{bestInput} was the best input with an accuracy of {bestAccuracy}.");
        }
        public static double RunSimulation(double guess)
        {
            return guess;
            double timestep = 0.0000001;
            double time = 0;
            int iterations = 0;

            double positionX = 0;
            double positionY = 0;

            double velocityX = 6.260990337;
            double velocityY = 0;

            double accelerationX = 0;
            double accelerationY = guess;

            while (velocityX >= 0)
            {
                positionX += velocityX * timestep;
                positionY += velocityY * timestep;

                velocityX += accelerationX * timestep;
                velocityY += accelerationY * timestep;

                time += timestep;
                iterations++;
            }

            return positionX;
        }
        public static void RunSimulation()
        {
            double timestep = 0.000001;
            double time = 0;
            int iterations = 0;

            double positionX = 0;
            double positionY = 0;

            double velocityX = 20;
            double velocityY = 0;

            double accelerationX = -1;
            double accelerationY = 0;

            while (positionX <= 200)
            {
                positionX += velocityX * timestep;
                positionY += velocityY * timestep;

                velocityX += accelerationX * timestep;
                velocityY += accelerationY * timestep;

                time += timestep;
                iterations++;
            }

            System.Console.WriteLine($"Timestep is {timestep}. Time is {time}. Iterations is {iterations}.");
            System.Console.WriteLine($"Position is ({positionX}, {positionY}).");
            System.Console.WriteLine($"Velocity is ({velocityX}, {velocityY}).");
            System.Console.WriteLine($"Accelerations is ({accelerationX}, {accelerationY}).");

            System.Console.ReadLine();
        }
    }
}