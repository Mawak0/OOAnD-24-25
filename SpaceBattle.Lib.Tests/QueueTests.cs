using Xunit;
namespace SpaceBattle.Lib.Tests;

public class QueueTests
{
    [Fact]
    public void QueueTest()
    {
        var queue = new Queue();
        var command = new EmptyCommand();
        queue.Add(command);

        Assert.Equal(command, queue.Take());
    }

    [Fact]
    public void EmptyQueueTest()
    {
        var queue = new Queue();

        Assert.Throws<Exception>(() => queue.Take());
    }
}
