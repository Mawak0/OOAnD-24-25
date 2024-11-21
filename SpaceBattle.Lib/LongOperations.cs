namespace SpaceBattle.Lib;

public class RepeatCommand : ICommand
{
    private readonly Queue _q;
    private readonly ICommand _toRepeat;
    public RepeatCommand(Queue q, ICommand toRepeat)
    {
        _q = q;
        _toRepeat = toRepeat;
    }

    public void Execute()
    {
        _q.Add(_toRepeat);
    }
}

public interface Injectable
{
    void Inject(ICommand cmd);
}

public class InjectableMacroCommand : ICommand, Injectable
{
    private ICommand _cmd = new EmptyCommand();
    public void Execute()
    {
        _cmd.Execute();
    }
    public void Inject(ICommand cmd)
    {
        _cmd = cmd;
    }
}
