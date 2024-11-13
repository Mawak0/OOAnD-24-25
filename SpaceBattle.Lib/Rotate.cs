namespace SpaceBattle.Lib;

public interface IRotate
{
    Angle PositionAngle { get; set;}
    Angle VelocityAngle { get; }
}

public interface ICommand
{
    public void Execute();
}

public class RotateCommand : ICommand
{
    private IRotate obj;
    public RotateCommand(IRotate obj)
    {
        this.obj = obj;
    }
    public void Execute()
    {
        obj.PositionAngle += obj.VelocityAngle;
    }
}
