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

    private void Execute()
    {
        _Queue.Add(_toRepeat);
    }
}

internal interface Injectable
{
    void Inject(ICommand cmd);
}
