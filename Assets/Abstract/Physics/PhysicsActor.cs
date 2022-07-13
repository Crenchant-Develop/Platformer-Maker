
//물리적인 행동을 하는 객체
public abstract class PhysicsActor : IActionable<PhysicsState>
{
    public PhysicsState State { get; set; }
    PhysicsState IStatable<PhysicsState>.Handle => State;


    public abstract void Invoke();
}