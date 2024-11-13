namespace SpaceBattle.Lib;
using Moq;

public interface IVector
{
    public int Length {get;}
    public int[] Values {get; set;}
}


public class Vector: IVector
{
    private readonly IVector obj;

    public Vector(IVector obj)
    {
        this.obj = obj;
    }

    public int this[int index]
    {
        get => obj.Values[index];
        set => obj.Values[index] = value;
    }

    public int[] Values
    {
       get => obj.Values;
       set => obj.Values = value;
    }
    public int Length => obj.Values.Length;

    public static Vector operator +(Vector v1, Vector v2)
    {
        if (v1.Length != v2.Length)
            throw new ArgumentException("Vectors must be of the same length");
        var result = v1.Values.Zip(v2.Values, (a, b) => a + b).ToArray();
        var mockVector = new Mock<IVector>();
        mockVector.SetupGet(m => m.Values).Returns(result);
        var resVector = new Vector(mockVector.Object);
        return resVector;
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
     public override bool Equals(object obj)
        {
            return obj is Vector vector && this == vector;
        }

    public override int GetHashCode()
        {
            return obj.Values.Aggregate(17, (current, value) => current * 23 + value.GetHashCode());
        }

    public override string ToString()
    {
        return $"[{string.Join(", ", obj.Values)}]";
    }
}
