using Moq;
using Xunit;
namespace SpaceBattle.Lib.Tests;

public class LongRotateTests
{
    [Fact]
    public void StartRotateCommandTest()
    {
        var queue = new Queue();

        var Vector1 = new Mock<IVector>();
        Vector1.SetupGet(v => v.Values).Returns(new int[] { 1, 8 });
        var VelocityAngle = new Angle(Vector1.Object);

        var Vector2 = new Mock<IVector>();
        Vector2.SetupGet(v => v.Values).Returns(new int[] { 0, 8 });
        var PositionAngle = new Angle(Vector2.Object);

        var Vector3 = new Mock<IVector>();
        Vector3.SetupGet(v => v.Values).Returns(new int[] { 2, 8 });
        var TargetPositionAngle = new Angle(Vector3.Object);

        var game_obj = new Dictionary<string, object>();
        game_obj["PositionAngle"] = PositionAngle;

        var start_rotate_order = new Mock<StartRotateOrder>();
        start_rotate_order.SetupGet(m => m.VelocityAngle).Returns(VelocityAngle);
        start_rotate_order.SetupGet(m => m.GameObject).Returns(game_obj);

        var start_rotate_cmd = new StartRotateCommand(start_rotate_order.Object, queue);

        start_rotate_cmd.Execute();

        queue.Take().Execute();
        queue.Take().Execute();

        Assert.Equal(TargetPositionAngle, game_obj["PositionAngle"]);
    }

    [Fact]
    public void StopMoveCommandTest()
    {
        var queue = new Queue();

        var Vector1 = new Mock<IVector>();
        Vector1.SetupGet(v => v.Values).Returns(new int[] { 1, 8 });
        var VelocityAngle = new Angle(Vector1.Object);

        var Vector2 = new Mock<IVector>();
        Vector2.SetupGet(v => v.Values).Returns(new int[] { 0, 8 });
        var PositionAngle = new Angle(Vector2.Object);

        var game_obj = new Dictionary<string, object>();
        game_obj["PositionAngle"] = PositionAngle;

        var start_rotate_order = new Mock<StartRotateOrder>();
        start_rotate_order.SetupGet(m => m.VelocityAngle).Returns(VelocityAngle);
        start_rotate_order.SetupGet(m => m.GameObject).Returns(game_obj);

        var start_rotate_cmd = new StartRotateCommand(start_rotate_order.Object, queue);

        var stop_rotate_cmd = new StopRotateCommand(game_obj);

        start_rotate_cmd.Execute();

        queue.Take().Execute();
        stop_rotate_cmd.Execute();
        queue.Take().Execute();

        Assert.Throws<Exception>(() => queue.Take().Execute());
    }

    [Fact]
    public void AdapterDefaultValuesTest()
    {
        var dictionary = new Dictionary<string, object>();
        var adapter = new RotateAdapter(dictionary);

        Assert.Equal(default(Angle), adapter.PositionAngle);
        Assert.Equal(default(Angle), adapter.VelocityAngle);
    }
}
