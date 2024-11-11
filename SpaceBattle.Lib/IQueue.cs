public interface ISender{
    public ICommand Take();
}

public interface IReceiver{
    public void Add(ICommand icom);
}

public class Queue: ISender, IReceiver {

    Queue<ICommand> qdata;
    public void Add(ICommand cmd){
        qdata.Enqueue(cmd);
    }

    public ICommand Take(){
        var qelem = qdata.Dequeue();
        return qelem;
    }
}