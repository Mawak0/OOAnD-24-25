using Moq;
using Xunit;
namespace SpaceBattle.Lib.Tests;

public class MoveCommandTests
{
    [Fact]
    public void Execute_CorrectPositionChange()
    {
        var mockMoving = new Mock<IMoving>();
        mockMoving.SetupGet(m => m.Position).Returns(new Vector([12, 5]));
        mockMoving.SetupGet(m => m.Velocity).Returns(new Vector([-7, 3]));

        var command = new MoveCommand(mockMoving.Object);

        command.Execute();

        mockMoving.VerifySet(m => m.Position = new Vector([5, 8]), Times.Once);
    }

    [Fact]
    public void Execute_UnreadablePosition_ThrowsException()
    {
        var mockMoving = new Mock<IMoving>();
        mockMoving.SetupGet(m => m.Position).Throws<InvalidOperationException>();
        mockMoving.SetupGet(m => m.Velocity).Returns(new Vector([-7, 3]));

        var command = new MoveCommand(mockMoving.Object);

        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }

    [Fact]
    public void Execute_UnreadableVelocity_ThrowsException()
    {
        var mockMoving = new Mock<IMoving>();
        mockMoving.SetupGet(m => m.Position).Returns(new Vector([12, 5]));
        mockMoving.SetupGet(m => m.Velocity).Throws<InvalidOperationException>();

        var command = new MoveCommand(mockMoving.Object);

        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }

    [Fact]
    public void Execute_UnchangeablePosition_ThrowsException()
    {
        var mockMoving = new Mock<IMoving>();
        mockMoving.SetupGet(m => m.Position).Returns(new Vector([12, 5]));
        mockMoving.SetupSet(m => m.Position = It.IsAny<Vector>()).Throws<InvalidOperationException>();
        mockMoving.SetupGet(m => m.Velocity).Returns(new Vector([-7, 3]));

        var command = new MoveCommand(mockMoving.Object);

        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }
}
