using Moq;
using Xunit;
namespace SpaceBattle.Lib.Tests;

public class MoveCommandTests
{
    [Fact]
    public void Execute_CorrectPositionChange()
    {
        var moqVector1 = new Mock<IVector>();
        moqVector1.SetupGet(v => v.Values).Returns(new int[] { 12, 5 });
        var vector1 = new Vector(moqVector1.Object);

        var moqVector2 = new Mock<IVector>();
        moqVector2.SetupGet(v => v.Values).Returns(new int[] { -7, 3 });
        var vector2 = new Vector(moqVector2.Object);

        var moqVector3 = new Mock<IVector>();
        moqVector3.SetupGet(v => v.Values).Returns(new int[] { 5, 8 });
        var vector3 = new Vector(moqVector3.Object);

        var mockMoving = new Mock<IMoving>();
        mockMoving.SetupGet(m => m.Position).Returns(vector1);
        mockMoving.SetupGet(m => m.Velocity).Returns(vector2);

        var command = new MoveCommand(mockMoving.Object);

        command.Execute();

        mockMoving.VerifySet(m => m.Position = vector3, Times.Once);
    }

    [Fact]
    public void Execute_UnreadablePosition_ThrowsException()
    {
        var moqVector1 = new Mock<IVector>();
        moqVector1.SetupGet(v => v.Values).Returns(new int[] { -7, 3 });
        var vector1 = new Vector(moqVector1.Object);

        var mockMoving = new Mock<IMoving>();
        mockMoving.SetupGet(m => m.Position).Throws<InvalidOperationException>();
        mockMoving.SetupGet(m => m.Velocity).Returns(vector1);

        var command = new MoveCommand(mockMoving.Object);

        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }

    [Fact]
    public void Execute_UnreadableVelocity_ThrowsException()
    {
        var moqVector1 = new Mock<IVector>();
        moqVector1.SetupGet(v => v.Values).Returns(new int[] { 12, 5 });
        var vector1 = new Vector(moqVector1.Object);

        var mockMoving = new Mock<IMoving>();
        mockMoving.SetupGet(m => m.Position).Returns(vector1);
        mockMoving.SetupGet(m => m.Velocity).Throws<InvalidOperationException>();

        var command = new MoveCommand(mockMoving.Object);

        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }

    [Fact]
    public void Execute_UnchangeablePosition_ThrowsException()
    {
        var moqVector1 = new Mock<IVector>();
        moqVector1.SetupGet(v => v.Values).Returns(new int[] { 12, 5 });
        var vector1 = new Vector(moqVector1.Object);

        var moqVector2 = new Mock<IVector>();
        moqVector2.SetupGet(v => v.Values).Returns(new int[] { -7, 3 });
        var vector2 = new Vector(moqVector2.Object);

        var mockMoving = new Mock<IMoving>();
        mockMoving.SetupGet(m => m.Position).Returns(vector1);
        mockMoving.SetupSet(m => m.Position = It.IsAny<Vector>()).Throws<InvalidOperationException>();
        mockMoving.SetupGet(m => m.Velocity).Returns(vector2);
        var command = new MoveCommand(mockMoving.Object);

        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }
}
