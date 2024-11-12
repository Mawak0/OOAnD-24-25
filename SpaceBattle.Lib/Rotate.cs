namespace SpaceBattle.Lib;

public interface IRotate
{
    int[] PositionAngle { get; set;}
    int[] VelocityAngle { get; }
}

public interface ICommand
{
    public void Execute();
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
        obj.PositionAngle = new int[]{
            obj.PositionAngle[0] + obj.VelocityAngle[0],
            obj.PositionAngle[1] + 0,
        };

        obj.PositionAngle[0] = obj.PositionAngle[0] % obj.PositionAngle[1];

    }
}
