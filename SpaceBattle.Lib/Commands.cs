public interface ICommand
{
    public void Execute();
}

public class Start : ICommand
{
    private ICommand exCom;
    public void Execute()
    {
        queue.Add(exCom);
    }

    public void SetCommand(ICommand c)
    {
        exCom = c;
    }
}

public class End : ICommand
{
    public void Execute()
    {
        queue.Take();
    }
}

public class MCommand : ICommand
{
    private readonly ICommand com;
    private readonly object rcom;

    public MCommand(ICommand c, ref ICommand rc)
    {
        com = c;
        rcom = rc;
    }

    public void Execute()
    {
        com.Execute();
        queue.Add(rcom);
    }
}
