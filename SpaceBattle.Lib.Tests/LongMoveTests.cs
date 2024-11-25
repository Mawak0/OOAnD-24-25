using Moq;
using Xunit;
namespace SpaceBattle.Lib.Tests;

public class LongMoveTests
{
    [Fact]
    public void StartMoveCommandTest()
    {
        var queue = new Queue();

        var Vector1 = new Mock<IVector>();
        Vector1.SetupGet(v => v.Values).Returns(new int[] { 1, 1 });
        var velocity = new Vector(Vector1.Object);

        var Vector2 = new Mock<IVector>();
        Vector2.SetupGet(v => v.Values).Returns(new int[] { 0, 0 });
        var Position = new Vector(Vector2.Object);

        var Vector3 = new Mock<IVector>();
        Vector3.SetupGet(v => v.Values).Returns(new int[] { 2, 2 });
        var TargetPosition = new Vector(Vector3.Object);

        var game_obj = new Dictionary<string, object>();
        game_obj["Position"] = Position;

        var start_move_order = new Mock<StartMoveOrder>();
        start_move_order.SetupGet(m => m.velocity).Returns(velocity);
        start_move_order.SetupGet(m => m.GameObject).Returns(game_obj);

        var start_move_cmd = new StartMoveCommand(start_move_order.Object, queue);

        start_move_cmd.Execute();

        queue.Take().Execute();
        queue.Take().Execute();

        Assert.Equal(TargetPosition, game_obj["Position"]);
    }
}
