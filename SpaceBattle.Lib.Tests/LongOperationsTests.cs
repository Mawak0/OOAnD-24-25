using Xunit;
namespace SpaceBattle.Lib.Tests;

public class LongOperationsTests
{
    [Fact]
    public void RepeatCommandTest()
    {
        var queue = new Queue();
        var cmd = new EmptyCommand();
        var repeat_cmd = new RepeatCommand(queue, cmd);
        repeat_cmd.Execute();
        Assert.Equal(cmd, queue.Take());
    }

    [Fact]
    public void InjectableCommandTest()
    {
        var cmd = new EmptyCommand();
        var inj_cmd = new InjectableCommand();
        inj_cmd.Inject(cmd);
        inj_cmd.Execute();
    }
}
