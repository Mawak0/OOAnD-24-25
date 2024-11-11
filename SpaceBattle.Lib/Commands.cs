namespace SpaceBattle.Lib;

public interface ICommand
{
    public void Execute();
}

public class Start : ICommand
{
    private readonly ICommand exCom;
    private readonly Queue refQueue;

    public Start(ref Queue q, ref ICommand c)
    {
        exCom = c;
        refQueue = q;
    }
    public void Execute()
    {
        refQueue.Add(exCom);
    }
}

public class End : ICommand
{
    private readonly Queue refQueue;

    public End(ref Queue q)
    {
        refQueue = q;
    }
    public void Execute()
    {
        refQueue.Take();
    }
}

public class MCommand : ICommand
{
    private readonly ICommand com;
    private readonly ICommand rcom;

    private readonly Queue refQueue;

    public MCommand(ref Queue q, ICommand c, ref ICommand rc)
    {
        refQueue = q;
        com = c;
        rcom = rc;
    }

    public void Execute()
    {
        com.Execute();
        refQueue.Add(rcom);
    }
}
