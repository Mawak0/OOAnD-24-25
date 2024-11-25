namespace SpaceBattle.Lib;
public interface IRotate
{
    Angle PositionAngle { get; set; }
    Angle VelocityAngle { get; }
}

public class RotateCommand : ICommand
{
    private readonly IRotate obj;
    public RotateCommand(IRotate obj)
    {
        this.obj = obj;
    }
    public void Execute()
    {
        obj.PositionAngle += obj.VelocityAngle;
    }
}

public class RotateAdapter : IRotate
{
    private readonly IDictionary<string, object> _dictionary;

    public RotateAdapter(IDictionary<string, object> dictionary)
    {
        _dictionary = dictionary;
    }

    public Angle PositionAngle
    {
        get
        {
            if (_dictionary.TryGetValue(nameof(PositionAngle), out var value))
            {
                return (Angle)value;
            }

            return default;
        }
        set => _dictionary[nameof(PositionAngle)] = value;
    }

    public Angle VelocityAngle
    {
        get
        {
            if (_dictionary.TryGetValue(nameof(VelocityAngle), out var value))
            {
                return (Angle)value;
            }

            return default;
        }
    }
}

public interface StartRotateOrder
{
    IDictionary<string, object> GameObject { get; }
    Angle VelocityAngle { get; }
}

public class StartRotateCommand : ICommand
{
    private readonly StartRotateOrder _order;
    private readonly Queue _queue;
    public StartRotateCommand(StartRotateOrder order, Queue queue)
    {
        _order = order;
        _queue = queue;
    }
    public void Execute()
    {
        IRotate RotateGameObject = new RotateAdapter(_order.GameObject);
        _order.GameObject["VelocityAngle"] = _order.VelocityAngle;
        var rotateCommand = new RotateCommand(RotateGameObject);

        var injectable = new InjectableCommand();

        var repeat = new RepeatCommand(_queue, injectable);
        var repeatableRotate = new MCommand(new List<ICommand> { rotateCommand, repeat });

        injectable.Inject(repeatableRotate);
        _order.GameObject["repeatableRotate"] = injectable;
        _queue.Add(repeatableRotate);
    }
}

public class StopRotateCommand : ICommand
{
    private readonly IDictionary<string, object> _gameObject;
    public StopRotateCommand(IDictionary<string, object> gameObject)
    {
        _gameObject = gameObject;
    }
    public void Execute()
    {
        var injectable = (Injectable)_gameObject["repeatableRotate"];
        injectable.Inject(new EmptyCommand());
    }
}
