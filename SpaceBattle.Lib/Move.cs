namespace SpaceBattle.Lib;

public interface IMoving
{
    Vector Position { get; set; }
    Vector Velocity { get; }
}

public interface ICommand
{
    public void Execute();
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
