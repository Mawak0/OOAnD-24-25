using Moq;
using Xunit;
namespace SpaceBattle.Lib.Tests;

public class VectorTests
{
    [Fact]
    public void Execute_Adding()
    {
        var moqVector1 = new Mock<IVector>();
        moqVector1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqVector2 = new Mock<IVector>();
        moqVector2.SetupGet(v => v.Values).Returns(new int[] { 2, 9 });

        var moqResVector = new Mock<IVector>();
        moqResVector.SetupGet(v => v.Values).Returns(new int[] { 5, 14 });

        var vector1 = new Vector(moqVector1.Object);
        var vector2 = new Vector(moqVector2.Object);
        var resVector = new Vector(moqResVector.Object);
        var newVector = vector1 + vector2;

        Assert.Equal(newVector, resVector);
    }

    [Fact]
    public void Execute_IncorrectDimensions_ThrowsException()
    {
        var moqVector1 = new Mock<IVector>();
        moqVector1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqVector2 = new Mock<IVector>();
        moqVector2.SetupGet(v => v.Values).Returns(new int[] { 2, 9, 7 });

        var moqResVector = new Mock<IVector>();
        moqResVector.SetupGet(v => v.Values).Returns(new int[] { 5, 14 });

        var vector1 = new Vector(moqVector1.Object);
        var vector2 = new Vector(moqVector2.Object);

        Assert.Throws<ArgumentException>(() => vector1 + vector2);
    }

    [Fact]
    public void Execute_GetByIndex()
    {
        var moqVector = new Mock<IVector>();
        moqVector.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });
        var vector = new Vector(moqVector.Object);

        Assert.Equal(3, vector[0]);
    }

    [Fact]
    public void Execute_IndexOutOfRange_ThrowsException()
    {
        var moqVector = new Mock<IVector>();
        moqVector.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });
        var vector = new Vector(moqVector.Object);

        Assert.Throws<IndexOutOfRangeException>(() => vector[666]);
    }

    [Fact]
    public void Execute_EqualTrue()
    {
        var moqVector1 = new Mock<IVector>();
        moqVector1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqVector2 = new Mock<IVector>();
        moqVector2.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var vector1 = new Vector(moqVector1.Object);
        var vector2 = new Vector(moqVector2.Object);

        Assert.True(vector1 == vector2);
    }

    [Fact]
    public void Execute_EqualFalse()
    {
        var moqVector1 = new Mock<IVector>();
        moqVector1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqVector2 = new Mock<IVector>();
        moqVector2.SetupGet(v => v.Values).Returns(new int[] { 9, 5 });

        var vector1 = new Vector(moqVector1.Object);
        var vector2 = new Vector(moqVector2.Object);

        Assert.False(vector1 == vector2);
    }

    [Fact]
    public void Execute_Equal_ThrowsException()
    {
        var moqVector1 = new Mock<IVector>();
        moqVector1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqVector2 = new Mock<IVector>();
        moqVector2.SetupGet(v => v.Values).Returns(new int[] { 3, 5, 4 });

        var vector1 = new Vector(moqVector1.Object);
        var vector2 = new Vector(moqVector2.Object);

        Assert.Throws<ArgumentException>(() => vector1 == vector2);
    }

    [Fact]
    public void Execute_NotEqualFalse()
    {
        var moqVector1 = new Mock<IVector>();
        moqVector1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqVector2 = new Mock<IVector>();
        moqVector2.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var vector1 = new Vector(moqVector1.Object);
        var vector2 = new Vector(moqVector2.Object);

        Assert.False(vector1 != vector2);
    }

    [Fact]
    public void Execute_NotEqualTrue()
    {
        var moqVector1 = new Mock<IVector>();
        moqVector1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqVector2 = new Mock<IVector>();
        moqVector2.SetupGet(v => v.Values).Returns(new int[] { 9, 5 });

        var vector1 = new Vector(moqVector1.Object);
        var vector2 = new Vector(moqVector2.Object);

        Assert.True(vector1 != vector2);
    }

    [Fact]
    public void Execute_NotEqual_ThrowsException()
    {
        var moqVector1 = new Mock<IVector>();
        moqVector1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqVector2 = new Mock<IVector>();
        moqVector2.SetupGet(v => v.Values).Returns(new int[] { 3, 5, 4 });

        var vector1 = new Vector(moqVector1.Object);
        var vector2 = new Vector(moqVector2.Object);

        Assert.Throws<ArgumentException>(() => vector1 != vector2);
    }

    [Fact]
    public void Execute_Print()
    {
        var moqVector = new Mock<IVector>();
        moqVector.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var vector = new Vector(moqVector.Object);

        Assert.Equal("[3, 5]", vector.ToString());
    }

    [Fact]
    public void Execute_SetByIndex()
    {
        var moqVector = new Mock<IVector>();
        moqVector.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var vector = new Vector(moqVector.Object);

        var moqResVector = new Mock<IVector>();
        moqResVector.SetupGet(v => v.Values).Returns(new int[] { 10, 5 });

        var resVector = new Vector(moqResVector.Object);

        vector[0] = 10;

        Assert.Equal(resVector, vector);
    }

    [Fact]
    public void Execute_GetHashCode()
    {
        var moqVector1 = new Mock<IVector>();
        moqVector1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var vector1 = new Vector(moqVector1.Object);

        var moqVector2 = new Mock<IVector>();
        moqVector2.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var vector2 = new Vector(moqVector2.Object);

        Assert.True(vector1.GetHashCode() == vector2.GetHashCode());
    }
}
