public interface IControllable<T> : IStateConnectable<T>
where T : class, new()
{
}