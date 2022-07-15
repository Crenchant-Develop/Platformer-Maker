
class MyConnectable<T> : IStateConnectable<T, MyState<T>>
{
    public MyState<T> State { get; }

    public T Handle { get; set; }

    public MyConnectable()
    {
        MyState<T> state = new(this);
    }
}

class MyState<T> : IStatable<T>
{
    public IStateConnectable<T, IStatable<T>> StateConnectable { get; }

    public MyState(IStateConnectable<T, IStatable<T>> stateConnectable)
    {
        StateConnectable = stateConnectable;
    }
}