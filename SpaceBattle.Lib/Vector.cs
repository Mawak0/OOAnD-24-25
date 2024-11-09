using System;


public interface IVector
{
    public int Length {get;}
    public int[] Values {get; set;}
}


public class Vector: IVector
{
    int[] elements;

    public Vector(int size)
    {
        elements = new int[size];
    }
    public Vector(int[] values)
    {
        elements = new int[values.Length];
        values.CopyTo(elements, 0);
    }

    public int this[int index]
    {
        get => elements[index];
        set => elements[index] = value;
    }

    public int[] Values
    {
       get => elements;
       set => elements = value;
    }
    public int Length => elements.Length;

    public static Vector operator +(Vector v1, Vector v2)
    {
        if (v1.Length != v2.Length)
            throw new ArgumentException("Vectors must be of the same length");
        var result = v1.Values.Zip(v2.Values, (a, b) => a + b).ToArray();
        return new Vector(result);
    }
    public static bool operator ==(Vector v1, Vector v2)
    {
        if (v1.Length != v2.Length)
            throw new ArgumentException("Vectors must be of the same length");
        var result = v1.Values.SequenceEqual(v2.Values);
        return result;
    }
    public static bool operator !=(Vector v1, Vector v2)
    {
        if (v1.Length != v2.Length)
            throw new ArgumentException("Vectors must be of the same length");
        var result = v1.Values.SequenceEqual(v2.Values);
        return !result;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", elements)}]";
    }
}