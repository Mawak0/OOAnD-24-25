namespace SpaceBattle.Lib;

public interface IMoving
{
    Vector Position { get; set; }
    Vector Velocity { get; }
}

public class MovingAdapter : IMoving
{
    private readonly IDictionary<string, object> _dictionary;

    public MovingAdapter(IDictionary<string, object> dictionary)
    {
        _dictionary = dictionary;
    }

    public Vector Position
    {
        get
        {
            if (_dictionary.TryGetValue(nameof(Position), out var value) && value is Vector vector)
            {
                return vector;
            }

            return default;
        }
        set => _dictionary[nameof(Position)] = value;
    }

    public Vector Velocity
    {
        get
        {
            if (_dictionary.TryGetValue(nameof(Velocity), out var value) && value is Vector vector)
            {
                return vector;
            }

            return default;
        }
    }
}

public class MoveCommand : ICommand
{
    private readonly IMoving obj;
    public MoveCommand(IMoving obj)
    {
        this.obj = obj;
    }
    public void Execute()
    {
        obj.Position = obj.Position + obj.Velocity;
    }
}

public interface StartMoveOrder
{
    IDictionary<string, object> GameObject { get; }
    Vector velocity { get; }
}

public class StartMoveCommand : ICommand
{
    private readonly StartMoveOrder _order;
    private readonly Queue _queue;
    public StartMoveCommand(StartMoveOrder order, Queue queue)
    {
        _order = order;
        _queue = queue;
    }
    public void Execute()
    {
        IMoving MovingGameObject = new MovingAdapter(_order.GameObject);
        _order.GameObject["Velocity"] = _order.velocity;
        var moveCommand = new MoveCommand(MovingGameObject);

        var injectable = new InjectableCommand();

        var repeat = new RepeatCommand(_queue, injectable);
        var repeatableMove = new MCommand(new List<ICommand> { moveCommand, repeat });

        injectable.Inject(repeatableMove);
        _order.GameObject["repeatableMove"] = injectable;
        _queue.Add(repeatableMove);
    }
}

public class StopMoveCommand : ICommand
{
    private readonly IDictionary<string, object> _gameObject;
    public StopMoveCommand(IDictionary<string, object> gameObject)
    {
        _gameObject = gameObject;
    }
    public void Execute()
    {
        var injectable = (Injectable)_gameObject["repeatableMove"];
        injectable.Inject(new EmptyCommand());
    }
}
