using System;


public interface IVector
{
    public int Length {get;}
    public int[] Values {get; set;}
}


public class Vector: IVector
{
    private int[] elements;

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
    public int Length
    { 
        get => elements.Length;
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        if (v1.Length != v2.Length)
            throw new ArgumentException("Vectors must be of the same length");
        var result = array1.Zip(array2, (a, b) => a + b).ToArray();
        return new Vector(result);
    }
    public static bool operator ==(Vector v1, Vector v2)
    {
        return v1.CompareTo(v2) == 1;
    }
    public static bool operator !=(Vector v1, Vector v2)
    {
        return !(v1.CompareTo(v2) == 1);
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", elements)}]";
    }
}