namespace SpaceBattle.Lib;
using System;

public interface IRotate
{
    Vector PositionAngle { get; set;}
    Vector VelocityAngle { get; }
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
        obj.PositionAngle = new Vector{
            obj.PositionAngle[0] + obj.VelocityAngle[0],
            obj.PositionAngle[1] + 0,
        };

        obj.PositionAngle[0] = obj.PositionAngle[0] % obj.PositionAngle[1];
        double radians = Convert.ToDouble(2 * obj.PositionAngle[0] * 22) / Convert.ToDouble(obj.VelocityAngle[1] * 7);
        double degrees = Convert.ToDouble(obj.PositionAngle[0] * 360) / Convert.ToDouble(obj.VelocityAngle[1]);

        Console.WriteLine($"parts: {obj.PositionAngle[0]} / {obj.PositionAngle[1]}");
        Console.WriteLine($"radians: {radians}");
        Console.WriteLine($"degrees: {degrees}");
    }
}
