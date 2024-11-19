using Moq;
using Xunit;
namespace SpaceBattle.Lib.Tests;

public class AngleTests
{
    [Fact]
    public void Execute_Adding()
    {
        var moqAngle1 = new Mock<IVector>();
        moqAngle1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqAngle2 = new Mock<IVector>();
        moqAngle2.SetupGet(v => v.Values).Returns(new int[] { 4, 5 });

        var moqResAngle = new Mock<IVector>();
        moqResAngle.SetupGet(v => v.Values).Returns(new int[] { 2, 5 });

        var angle1 = new Angle(moqAngle1.Object);
        var angle2 = new Angle(moqAngle2.Object);
        var resAngle = new Angle(moqResAngle.Object);
        var newAngle = angle1 + angle2;

        Assert.Equal(resAngle, newAngle);
    }

    [Fact]
    public void Execute_AddingWithDifferentDenominators()
    {
        var moqAngle1 = new Mock<IVector>();
        moqAngle1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqAngle2 = new Mock<IVector>();
        moqAngle2.SetupGet(v => v.Values).Returns(new int[] { 4, 7 });

        var angle1 = new Angle(moqAngle1.Object);
        var angle2 = new Angle(moqAngle2.Object);

        Assert.Throws<ArgumentException>(() => angle1 + angle2);
    }

    [Fact]
    public void Execute_GetByIndex()
    {
        var moqAngle = new Mock<IVector>();
        moqAngle.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });
        var angle = new Angle(moqAngle.Object);

        Assert.Equal(3, angle[0]);
    }

    [Fact]
    public void Execute_Equal()
    {
        var moqAngle1 = new Mock<IVector>();
        moqAngle1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqAngle2 = new Mock<IVector>();
        moqAngle2.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var angle1 = new Angle(moqAngle1.Object);
        var angle2 = new Angle(moqAngle2.Object);

        Assert.True(angle1 == angle2);
    }

    [Fact]
    public void Execute_NoEqual()
    {
        var moqAngle1 = new Mock<IVector>();
        moqAngle1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqAngle2 = new Mock<IVector>();
        moqAngle2.SetupGet(v => v.Values).Returns(new int[] { 4, 5 });

        var angle1 = new Angle(moqAngle1.Object);
        var angle2 = new Angle(moqAngle2.Object);

        Assert.False(angle1 == angle2);
    }

    [Fact]
    public void Execute_Equal_ThrowsException()
    {
        var moqAngle1 = new Mock<IVector>();
        moqAngle1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqAngle2 = new Mock<IVector>();
        moqAngle2.SetupGet(v => v.Values).Returns(new int[] { 3, 7 });

        var angle1 = new Angle(moqAngle1.Object);
        var angle2 = new Angle(moqAngle2.Object);

        Assert.Throws<ArgumentException>(() => angle1 == angle2);
    }

    [Fact]
    public void Execute_NotEqual()
    {
        var moqAngle1 = new Mock<IVector>();
        moqAngle1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqAngle2 = new Mock<IVector>();
        moqAngle2.SetupGet(v => v.Values).Returns(new int[] { 4, 5 });

        var angle1 = new Angle(moqAngle1.Object);
        var angle2 = new Angle(moqAngle2.Object);

        Assert.True(angle1 != angle2);
    }

    [Fact]
    public void Execute_NotEqual_ThrowsException()
    {
        var moqAngle1 = new Mock<IVector>();
        moqAngle1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var moqAngle2 = new Mock<IVector>();
        moqAngle2.SetupGet(v => v.Values).Returns(new int[] { 3, 7 });

        var angle1 = new Angle(moqAngle1.Object);
        var angle2 = new Angle(moqAngle2.Object);

        Assert.Throws<ArgumentException>(() => angle1 != angle2);
    }

    [Fact]
    public void Execute_AnglePrint()
    {
        var moqAngle = new Mock<IVector>();
        moqAngle.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var angle = new Angle(moqAngle.Object);

        Assert.Equal("Angle [3, 5] (216 deg)", angle.ToString());
    }

    [Fact]
    public void Execute_SetByIndex()
    {
        var moqAngle = new Mock<IVector>();
        moqAngle.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var angle = new Angle(moqAngle.Object);

        var moqResAngle = new Mock<IVector>();
        moqResAngle.SetupGet(v => v.Values).Returns(new int[] { 5, 5 });

        var resAngle = new Angle(moqResAngle.Object);

        angle[0] = 10;

        Assert.Equal(resAngle, angle);
    }

    [Fact]
    public void Execute_GetLength()
    {
        var moqAngle1 = new Mock<IVector>();
        moqAngle1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var angle1 = new Angle(moqAngle1.Object);

        Assert.Equal(2, angle1.Length);
    }

    [Fact]
    public void Execute_GetValues()
    {
        var moqAngle1 = new Mock<IVector>();
        moqAngle1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var angle1 = new Angle(moqAngle1.Object);

        Assert.Equal(new int[] {3, 5}, angle1.Values);
    }

    [Fact]
    public void Execute_SetValues()
    {
        var moqAngle1 = new Mock<IVector>();
        moqAngle1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var angle1 = new Angle(moqAngle1.Object);

        angle1.Values = new int[] {11, 33};

        Assert.Equal(new int[] {11, 33}, angle1.Values);
    }

    
    [Fact]
    public void Execute_GetHashCode()
    {
        var moqAngle1 = new Mock<IVector>();
        moqAngle1.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var angle1 = new Angle(moqAngle1.Object);

        var moqAngle2 = new Mock<IVector>();
        moqAngle2.SetupGet(v => v.Values).Returns(new int[] { 3, 5 });

        var angle2 = new Angle(moqAngle2.Object);

        Assert.True(angle1.GetHashCode() == angle2.GetHashCode());
    }
}
