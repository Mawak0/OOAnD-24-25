using Moq;
using Xunit;

namespace SpaceBattle.Lib.Tests;

public class MoveCommandTest
{

    [Fact]
    public void MoveCommandPositive()
    {
        var movable = new Mock<IRotate>();

        movable.SetupGet(m => m.PositionAngle).Returns([1, 8]).Verifiable();
        movable.SetupGet(m => m.VelocityAngle).Returns([2, 8]).Verifiable();

        ICommand moveCommand = new RotateCommand(movable.Object);

        moveCommand.Execute();

        movable.VerifySet(m => m.PositionAngle = [3, 8], Times.Once);
        movable.VerifyAll(); 
    }
}
