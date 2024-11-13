using Moq;
using Xunit;

namespace SpaceBattle.Lib.Tests;

public class RotateCommandTest
{

    [Fact]
    public void RotateCommandPositive()
    {
        var rotating = new Mock<IRotate>();
        
        rotating.SetupGet(m => m.PositionAngle).Returns(new Angle{1, 8}).Verifiable();
        rotating.SetupGet(m => m.VelocityAngle).Returns(new Angle{2, 8}).Verifiable();

        ICommand rotateCommand = new RotateCommand(rotating.Object);

        rotateCommand.Execute();

        rotating.VerifySet(m => m.PositionAngle = [3, 8], Times.Once);
        rotating.VerifyAll();
    }
}
