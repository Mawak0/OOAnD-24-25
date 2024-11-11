public class Angle: IVector
{
    int[] elements;

    public Angle(int[] values)
    {
        elements = new int[values.Length];
        makeCorrect();
        values.CopyTo(elements, 0);
    }

    public int this[int index]
    {
        get => elements[index];
        set 
        {
            elements[index] = value;
             makeCorrect();
        }
    }

    public int[] Values
    {
       get => elements;
       set => elements = value;
    }
    public int Length => elements.Length;

    public void makeCorrect()
    {
        if (elements[0] > elements[1])
            elements[0] -= elements[1];
    }

    public override string ToString()
    {
        return $"Angle [{string.Join(", ", elements)}] ({elements[0] / elements[1] * 360} deg)";
    }

    public static Angle operator +(Angle a1, Angle a2)
    {
        var result = a1.Values.Zip(a2.Values, (a, b) => a + b).ToArray();
        return new Angle(result);
    }

}