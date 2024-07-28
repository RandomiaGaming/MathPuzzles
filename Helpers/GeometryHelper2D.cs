using System;
using System.Collections.Generic;
public static class GeometryHelper2D
{
    //Radians and Degrees
    public static double RadToDeg(double radians)
    {
        return radians * (180 / Math.PI);
    }
    public static double DegToRad(double degrees)
    {
        return degrees * (Math.PI / 180);
    }
    //Degrees
    public static double DegreeClamp(double inputDegree)
    {
        while (inputDegree > 360)
        {
            inputDegree -= 360;
        }
        while (inputDegree < 0)
        {
            inputDegree += 360;
        }
        return inputDegree;
    }
    public static double DegreeDifference(double degreeA, double degreeB)
    {
        degreeA = DegreeClamp(degreeA);
        degreeB = DegreeClamp(degreeB);
        double Output = MathHelper.Abs(degreeA - degreeB);
        if (Output > 180)
        {
            Output = 360 - Output;
        }
        return MathHelper.Abs(Output);
    }
    //Vector2s
    public static Vector2 Vector2FromDirection(double direction, double magnitude)
    {
        return new Vector2(MathHelper.Cos(DegToRad(direction)), MathHelper.Sin(DegToRad(direction))) * magnitude;
    }
    public static Vector2 Vector2FromDirection(double direction)
    {
        return Vector2FromDirection(direction, 1);
    }
    public static double Distance(Vector2 vectorA, Vector2 vectorB)
    {
        return MathHelper.Sqrt(((vectorA.x - vectorB.x) * (vectorA.x - vectorB.x)) + ((vectorA.y - vectorB.y) * (vectorA.y - vectorB.y)));
    }
    public static Vector2 ClampUnitCircle(Vector2 inputVector2)
    {
        double Distance = Vector2Magnitude(inputVector2);
        return new Vector2(inputVector2.x / Distance, inputVector2.y / Distance);
    }
    public static double Vector2Direction(Vector2 inputVector2)
    {
        inputVector2 = ClampUnitCircle(inputVector2);
        double Output = RadToDeg(MathHelper.Atan(MathHelper.Abs(inputVector2.x) / MathHelper.Abs(inputVector2.y)));
        if (inputVector2.x >= 0 && inputVector2.y >= 0)
        {
            return 90 - Output;
        }
        else if (inputVector2.x < 0 && inputVector2.y >= 0)
        {
            return 90 + Output;
        }
        else if (inputVector2.x < 0 && inputVector2.y < 0)
        {
            return 180 + (90 - Output);
        }
        else if (inputVector2.x >= 0 && inputVector2.y < 0)
        {
            return 270 + Output;
        }
        else
        {
            return Output;
        }
    }
    public static double Vector2Magnitude(Vector2 inputVector2)
    {
        return MathHelper.Sqrt((inputVector2.x * inputVector2.x) + (inputVector2.y * inputVector2.y));
    }
    //Tringulation and Polygons
    public static List<List<Vector2>> Triangulate(List<Vector2> polygonPoints)
    {
        List<List<Vector2>> Output = new List<List<Vector2>>();
        while (polygonPoints.Count > 3)
        {
            int First_Convex_Vertice = -1;
            for (int i = 0; i < polygonPoints.Count; i++)
            {
                if (!VerticeConcave(polygonPoints, i))
                {
                    First_Convex_Vertice = i;
                    break;
                }
            }
            if (First_Convex_Vertice >= 0 && First_Convex_Vertice < polygonPoints.Count)
            {
                Vector2 Point_A = polygonPoints[First_Convex_Vertice];
                Vector2 Point_B = polygonPoints[First_Convex_Vertice];
                Vector2 Point_C = polygonPoints[First_Convex_Vertice];
                if (First_Convex_Vertice - 1 < 0)
                {
                    Point_A = polygonPoints[polygonPoints.Count - 1];
                }
                else
                {
                    Point_A = polygonPoints[First_Convex_Vertice - 1];
                }
                if (First_Convex_Vertice + 1 >= polygonPoints.Count)
                {
                    Point_C = polygonPoints[0];
                }
                else
                {
                    Point_C = polygonPoints[First_Convex_Vertice + 1];
                }
                Output.Add(new List<Vector2>() { Point_A, Point_B, Point_C });
                polygonPoints.RemoveAt(First_Convex_Vertice);
            }
            else
            {
                Output.Add(polygonPoints);
                return Output;
            }
        }
        Output.Add(polygonPoints);
        return Output;
    }
    public static bool PolygonConcave(List<Vector2> polygonPoints)
    {
        for (int i = 0; i < polygonPoints.Count; i++)
        {
            if (VerticeConcave(polygonPoints, i))
            {
                return true;
            }
        }
        return false;
    }
    public static bool VerticeConcave(List<Vector2> polygonPoints, int pointIndex)
    {
        Vector2 Point_A = polygonPoints[pointIndex];
        Vector2 Point_B = polygonPoints[pointIndex];
        Vector2 Point_C = polygonPoints[pointIndex];
        if (pointIndex - 1 < 0)
        {
            Point_A = polygonPoints[polygonPoints.Count - 1];
        }
        else
        {
            Point_A = polygonPoints[pointIndex - 1];
        }
        if (pointIndex + 1 >= polygonPoints.Count)
        {
            Point_C = polygonPoints[0];
        }
        else
        {
            Point_C = polygonPoints[pointIndex + 1];
        }
        double Degree_AB = Vector2Direction(new Vector2(Point_A.x - Point_B.x, Point_A.y - Point_B.y));
        double Degree_BC = Vector2Direction(new Vector2(Point_C.x - Point_B.x, Point_C.y - Point_B.y));
        if (Degree_BC > Degree_AB && Degree_BC - Degree_AB > 180)
        {
            return true;
        }
        else if (Degree_BC < Degree_AB && (360 - Degree_AB) + Degree_BC > 180)
        {
            return true;
        }
        return false;
    }
    //Lines and Stuff
    /*public static double distanceToLine(Vector2 lineStart, Vector2 lineEnd, Vector2 targetPoint)
    {
        return Distance(closestPointOnLine(lineStart, lineEnd, targetPoint), targetPoint);
    }
    public static Vector2 closestPointOnLine(Vector2 lineStart, Vector2 lineEnd, Vector2 targetPoint)
    {
        Vector2 line = (lineEnd - lineStart);
        double len = Vector2Magnitude(line);
        line.Normalize();

        Vector2 v = targetPoint - lineStart;
        double d = Vector2.Dot(v, line);
        d = MathHelper.Clamp(d, 0, len);
        return lineStart + line * d;
    }*/
}