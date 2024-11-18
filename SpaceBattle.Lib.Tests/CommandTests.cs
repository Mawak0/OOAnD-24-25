using Xunit;
namespace SpaceBattle.Lib.Tests;

public class CommandToTest: ICommand
{
    int cnt;

    public void Execute(){
        cnt++;
    }

    public int getCount(){
        return cnt;
    }
}

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
        var ctt1 = new CommandToTest();
        var ctt2 = new CommandToTest();
        List<ICommand> lst = [ctt1, ctt2];
        var mc = new MCommand(lst);
        mc.Execute();

        Assert.Equal(2, ctt1.getCount() + ctt2.getCount());
    }
}
