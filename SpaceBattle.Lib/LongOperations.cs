namespace SpaceBattle.Lib;

internal class RepeatCommand : ICommand
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

internal interface Injectable
{
    void Inject(ICommand cmd);
}
