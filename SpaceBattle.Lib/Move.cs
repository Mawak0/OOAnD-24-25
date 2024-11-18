using Hwdtech;

namespace SpaceBattle.Lib;

public interface IMoving
{
    Vector Position { get; set; }
    Vector Velocity { get; }
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

public interface StartMoveOrder {
    object ObjectID {get; }
    object GameID {get; }
    Vector velocity {get; }
}

public class StartMoveCommand: ICommand{
    private readonly StartMoveOrder _order;
    public StartMoveCommand(StartMoveOrder order){
        _order = order;
    }
    public void Execute(){
        var gameObject = IoC.Resolve<object>("Game.Object.GetById", _order.ObjectID);
        var setObjectVelocity = IoC.Resolve<ICommand>("Object.SetProperty", "velocity", _order.velocity);
        if (setObjectVelocity is ICommand setObjectVelocityCommand){
            setObjectVelocityCommand.Execute(); // !!!
        }
        if (gameObject is IMoving MovingObject){var c1 = new MoveCommand(MovingObject);}
        var inj_obj = new InjectableMacroCommand();
        var q_obj = IoC.Resolve<object>("Game.Queue");
        if (q_obj is Queue queue){var c2 = new RepeatCommand(queue, inj_obj);}
        var c3 = new MCommand(new List<ICommand> { c1, c2 });
        if (inj_obj is Injectable inj) {inj.Inject(c3);}
        
        // +write inj to gameObject
        
         if (q_obj is Queue queue){queue.Add(inj);}
    }
}