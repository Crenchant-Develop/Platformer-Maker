using System;

public class PhysicsInputController : IControllable<PhysicsState>
{
    public PhysicsState State { get; set; }
    PhysicsState IStatable<PhysicsState>.Handle => State;



    void OnStateUpdate() 
    {
        //State = value;
    }
}