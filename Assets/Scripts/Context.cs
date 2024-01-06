
using Assets.Character;

public class Context
{
    public State CurrentState { get; private set; }
    public GunController Gun { get; }

    public Context(State startingState, GunController gun)
    {
        Gun = gun;
        CurrentState = startingState;
        startingState.Enter(this);
    }

    public void ChangeState(State newState)
    {
        if (newState == CurrentState)
        {
            return;
        }

        CurrentState.Exit(this);

        CurrentState = newState;
        newState.Enter(this);
    }
    public void HandleInput()
    {
        CurrentState.HandleInput(this);
    }

    public void LogicUpdate()
    {
        CurrentState.LogicUpdate(this);
    }

    public void PhysicsUpdate()
    {
        CurrentState.PhysicsUpdate(this);
    }
}