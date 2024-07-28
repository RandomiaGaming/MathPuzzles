public struct Vector2Int
{
    public int x;
    public int y;
    public static readonly Vector2Int Zero = new Vector2Int(0, 0);
    public static readonly Vector2Int One = new Vector2Int(1, 1);
    public Vector2Int(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString()
    {
        return $"({x}, {y})";
    }
    public override bool Equals(object obj)
    {
        if (obj is null || obj.GetType() != typeof(Vector2Int))
        {
            return false;
        }
        else
        {
            return this == (Vector2Int)obj;
        }
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    public static bool operator ==(Vector2Int a, Vector2Int b)
    {
        return (a.x == b.x) && (a.y == b.y);
    }
    public static bool operator !=(Vector2Int a, Vector2Int b)
    {
        return !(a == b);
    }

    public static Vector2Int operator +(Vector2Int a, Vector2Int b)
    {
        return new Vector2Int(a.x + b.x, a.y + b.y);
    }
    public static Vector2Int operator -(Vector2Int a, Vector2Int b)
    {
        return new Vector2Int(a.x - b.x, a.y - b.y);
    }
    public static Vector2Int operator *(Vector2Int a, Vector2Int b)
    {
        return new Vector2Int(a.x * b.x, a.y * b.y);
    }
    public static Vector2Int operator /(Vector2Int a, Vector2Int b)
    {
        return new Vector2Int(a.x / b.x, a.y / b.y);
    }

    public static Vector2 operator +(Vector2Int a, Vector2 b)
    {
        return new Vector2(a.x + b.x, a.y + b.y);
    }
    public static Vector2 operator -(Vector2Int a, Vector2 b)
    {
        return new Vector2(a.x - b.x, a.y - b.y);
    }
    public static Vector2 operator *(Vector2Int a, Vector2 b)
    {
        return new Vector2(a.x * b.x, a.y * b.y);
    }
    public static Vector2 operator /(Vector2Int a, Vector2 b)
    {
        return new Vector2(a.x / b.x, a.y / b.y);
    }

    public static Vector2 operator +(Vector2Int a, double b)
    {
        return new Vector2(a.x + b, a.y + b);
    }
    public static Vector2 operator -(Vector2Int a, double b)
    {
        return new Vector2(a.x - b, a.y - b);
    }
    public static Vector2 operator *(Vector2Int a, double b)
    {
        return new Vector2(a.x * b, a.y * b);
    }
    public static Vector2 operator /(Vector2Int a, double b)
    {
        return new Vector2(a.x / b, a.y / b);
    }

    public static Vector2Int operator +(Vector2Int a, int b)
    {
        return new Vector2Int(a.x + b, a.y + b);
    }
    public static Vector2Int operator -(Vector2Int a, int b)
    {
        return new Vector2Int(a.x - b, a.y - b);
    }
    public static Vector2Int operator *(Vector2Int a, int b)
    {
        return new Vector2Int(a.x * b, a.y * b);
    }
    public static Vector2Int operator /(Vector2Int a, int b)
    {
        return new Vector2Int(a.x / b, a.y / b);
    }

    public static Vector2Int operator +(Vector2Int a)
    {
        return a;
    }
    public static Vector2Int operator -(Vector2Int a)
    {
        return new Vector2Int(a.x * -1, a.y * -1);
    }

    public static implicit operator Vector2Int(Vector2 a)
    {
        return new Vector2Int((int)a.x, (int)a.y);
    }
    public static implicit operator Vector2Int(Vector3 a)
    {
        return new Vector2Int((int)a.x, (int)a.y);
    }
    public static implicit operator Vector2Int(Vector3Int a)
    {
        return new Vector2Int(a.x, a.y);
    }
}