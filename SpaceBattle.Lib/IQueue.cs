public interface IQueue {
    void Add(ICommand cmd);
    ICommand Take();
}

public class Queue: IQueue {

    Queue<ICommand> qdata;
    public void Add(ICommand cmd){
        qdata.Enqueue(cmd);
    }

    public ICommand Take(){
        var qelem = qdata.Dequeue();
        return qelem;
    }
}