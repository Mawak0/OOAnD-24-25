using SpaceBattle.Lib;
using Moq;

public class Angle: IVector
{
    private readonly IVector obj;
    public Angle(IVector obj)
    {
        this.obj = obj;
    }

    public int this[int index]
    {
        get => obj.Values[index];
        set 
        {
            obj.Values[index] = value;
            makeCorrect();
        }
    }

    public int[] Values
    {
       get => obj.Values;
       set => obj.Values = value;
    }
    public int Length => obj.Values.Length;

    public void makeCorrect()
    {
        if (obj.Values[0] > obj.Values[1])
            obj.Values[0] -= obj.Values[1];
    }

    public override string ToString()
    {
        return $"Angle [{string.Join(", ", obj.Values)}] ({obj.Values[0] / obj.Values[1] * 360} deg)";
    }

    public static Angle operator +(Angle a1, Angle a2)
    {
        var result = a1.Values.Zip(a2.Values, (a, b) => a + b).ToArray();
        var mockAngle = new Mock<IVector>();
        mockAngle.SetupGet(a => a.Values).Returns(result);
        var resAngle = new Angle(mockAngle.Object);
        return resAngle;
    }

    public override bool Equals(object obj)
        {
            return obj is Angle angle && this == angle;
        }

    public override int GetHashCode()
        {
            return obj.Values.Aggregate(17, (current, value) => current * 23 + value.GetHashCode());
        }

}