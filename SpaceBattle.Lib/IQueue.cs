namespace SpaceBattle.Lib;

public interface ISender
{
    public ICommand Take();
}

public interface IReceiver
{
    public void Add(ICommand icom);
}

public class Queue : ISender, IReceiver
{
    private readonly Queue<ICommand> qdata = new Queue<ICommand>();
    public void Add(ICommand cmd)
    {
        qdata.Enqueue(cmd);
    }

    public ICommand Take()
    {
        var ok = qdata.TryDequeue(out var qelem);
        if (ok)
        {
            return qelem;
        }
        else
        {
            throw new Exception("There aren't any commands in queue!");
        }
    }
}
