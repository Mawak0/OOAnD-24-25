public interface ICommand
{
    public void Execute();
}

public class Start: ICommand
{
    ICommand exCom;
    public void Execute(){
        queue.Add(exCom);
    }

    public void SetCommand(ICommand c){
        exCom = c;
    }
}

public class End: ICommand
{
    public void Execute(){
        queue.Take();
    }
}