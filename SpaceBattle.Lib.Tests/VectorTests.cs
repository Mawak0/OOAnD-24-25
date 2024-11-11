using Moq;
using Xunit;
namespace SpaceBattle.Lib.Tests;

public class VectorTests
{
    [Fact]
    public void Execute_Adding()
    {
        var moqVector1 = new Mock<IVector>();
        moqVector1.SetupGet(v => v.Values).Returns(new int[]{3, 5});

        var moqVector2 = new Mock<IVector>();
        moqVector2.SetupGet(v => v.Values).Returns(new int[]{2, 9});

        var moqResVector = new Mock<IVector>();
        moqResVector.SetupGet(v => v.Values).Returns(new int[]{5, 14});

        var vector1 = new Vector(moqVector1.Object);
        var vector2 = new Vector(moqVector2.Object);
        var resVector = new Vector(moqResVector.Object);
        var newVector = vector1 + vector2;

        Assert.Equal(newVector, resVector);
    }

}