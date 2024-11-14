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
