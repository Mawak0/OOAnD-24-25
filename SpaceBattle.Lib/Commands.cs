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

public class MCommand: ICommand
{
    ICommand com;
    object rcom;

    public MCommand(ICommand c, ref ICommand rc){
        com = c;
        rcom = rc;
    }

    public void Execute(){
        com.Execute();
        queue.Add(rcom);
    }
}