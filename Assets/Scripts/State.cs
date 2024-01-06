
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class State
{
    protected State()
    {
    }

    public virtual void Enter(Context context)
    {
    }

    public virtual void HandleInput(Context context)
    {

    }

    public virtual void LogicUpdate(Context context)
    {

    }

    public virtual void PhysicsUpdate(Context context)
    {

    }

    public virtual void Exit(Context context)
    {

    }
}