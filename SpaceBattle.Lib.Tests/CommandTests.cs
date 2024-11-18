using Xunit;
namespace SpaceBattle.Lib.Tests;

public class CommandTests
{
    [Fact]
    public void CommandStartTest()
    {
        var queue = new Queue();
        var cmd = new EmptyCommand();
        var startCmd = new Start(ref queue, cmd);
        startCmd.Execute();

        Assert.Equal(cmd, queue.Take());
    }

    [Fact]
    public void CommandEndTest()
    {
        var queue = new Queue();
        var cmd = new EmptyCommand();
        var startCmd = new Start(ref queue, cmd);
        startCmd.Execute();
        var endCmd = new End(ref queue);
        endCmd.Execute();

        Assert.Throws<Exception>(() => queue.Take());
    }

    [Fact]
    public void MCommandTest()
    {
        var queue = new Queue();
        var cmd = new EmptyCommand();
        var mc = new MCommand(ref queue, cmd);
        mc.Execute();

        Assert.Equal(cmd, queue.Take());
    }
}
