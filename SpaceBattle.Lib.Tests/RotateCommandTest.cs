using Moq;
using Xunit;

namespace SpaceBattle.Lib.Tests;

public class RotateCommandTest
{

    [Fact]
    public void RotateCommandPositive()
    {

        var moqAng1 = new Mock<IVector>();
        moqAng1.SetupGet(v => v.Values).Returns(new int[] { 1, 8 }).Verifiable();

        var moqAng2 = new Mock<IVector>();
        moqAng2.SetupGet(v => v.Values).Returns(new int[] { 2, 8 }).Verifiable();

        var angle1 = new Angle(moqAng1.Object);
        var angle2 = new Angle(moqAng2.Object);

        var mockRotating = new Mock<IRotate>();
        mockRotating.SetupGet(v => v.PositionAngle).Returns(angle1).Verifiable();
        mockRotating.SetupGet(v => v.VelocityAngle).Returns(angle2).Verifiable();

        ICommand command = new RotateCommand(mockRotating.Object);
        command.Execute();

        mockRotating.VerifySet(v => v.PositionAngle = angle1 + angle2, Times.Once);
    }
}
