public interface IStateConnectable<out T> where T : class, IStatable
{
    public T State { get; }
}