using Moq;
using Xunit;
namespace SpaceBattle.Lib.Tests;



public class MoveCommandTests
{
    [Fact]
    public void Execute_CorrectPositionChange()
    {
        // Arrange
        var mockMoving = new Mock<IMoving>();
        mockMoving.SetupGet(m => m.Position).Returns(new int[] { 12, 5 });
        mockMoving.SetupGet(m => m.Velocity).Returns(new int[] { -7, 3 });

        var command = new MoveCommand(mockMoving.Object);

        // Act
        command.Execute();

        // Assert
        mockMoving.VerifySet(m => m.Position = new int[] { 5, 8 }, Times.Once);
    }

    [Fact]
    public void Execute_UnreadablePosition_ThrowsException()
    {
        // Arrange
        var mockMoving = new Mock<IMoving>();
        mockMoving.SetupGet(m => m.Position).Throws<InvalidOperationException>();
        mockMoving.SetupGet(m => m.Velocity).Returns(new int[] { -7, 3 });

        var command = new MoveCommand(mockMoving.Object);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }

    [Fact]
    public void Execute_UnreadableVelocity_ThrowsException()
    {
        // Arrange
        var mockMoving = new Mock<IMoving>();
        mockMoving.SetupGet(m => m.Position).Returns(new int[] { 12, 5 });
        mockMoving.SetupGet(m => m.Velocity).Throws<InvalidOperationException>();

        var command = new MoveCommand(mockMoving.Object);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }

    [Fact]
    public void Execute_UnchangeablePosition_ThrowsException()
    {
        // Arrange
        var mockMoving = new Mock<IMoving>();
        mockMoving.SetupGet(m => m.Position).Returns(new int[] { 12, 5 });
        mockMoving.SetupSet(m => m.Position = It.IsAny<int[]>()).Throws<InvalidOperationException>();
        mockMoving.SetupGet(m => m.Velocity).Returns(new int[] { -7, 3 });

        var command = new MoveCommand(mockMoving.Object);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }
}
