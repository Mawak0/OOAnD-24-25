using Moq;
using SpaceBattle.Lib;

public class Angle : IVector
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

    public int[] Values => obj.Values;

    public int Length => obj.Values.Length;

    public void makeCorrect()
    {
        if (obj.Values[0] > obj.Values[1])
        {
            obj.Values[0] -= obj.Values[1];
        }
    }

    public override string ToString()
    {
        return $"Angle [{string.Join(", ", obj.Values)}] ({(double)obj.Values[0] / (double)obj.Values[1] * 360} deg)";
    }

    public static Angle operator +(Angle a1, Angle a2)
    {
        if (a1[1] != a2[1])
        {
            throw new ArgumentException("Angels must be with the same denominator");
        }
        else
        {
            var result = new int[] { a1[0] + a2[0], a1[1] };
            var mockAngle = new Mock<IVector>();
            mockAngle.SetupGet(a => a.Values).Returns(result);
            var resAngle = new Angle(mockAngle.Object);
            resAngle.makeCorrect();
            return resAngle;
        }
    }

    public static bool operator ==(Angle a1, Angle a2)
    {
        if (a1[1] != a2[1])
        {
            throw new ArgumentException("Angels must be with the same denominator");
        }
        else
        {
            double[] coefs = [a1[0] / a2[0], a1[1] / a2[1]];
            if (coefs[0] == (int)coefs[0] && coefs[1] == (int)coefs[1])
            {
                return coefs[0] == coefs[1];
            }

            return false;
        }
    }

    public static bool operator !=(Angle a1, Angle a2)
    {
        return !(a1 == a2);
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
