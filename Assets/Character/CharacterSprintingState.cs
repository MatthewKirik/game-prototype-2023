using Assets.Character;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterSprintingState : State
{
    public CharacterSprintingState() : base()
    {
    }

    public override void Enter(Context context)
    {
        context.Gun.transform.localScale = Vector3.zero;

        base.Enter(context);
    }

    public override void HandleInput(Context context)
    {
        bool sprinting = Input.GetKey(KeyCode.LeftShift);
        
        if (!sprinting)
        {
            context.ChangeState(new CharacterRunningState());
        }

        base.HandleInput(context);
    }

    public override void Exit(Context context)
    {
        context.Gun.transform.localScale = Vector3.one;
        base.Exit(context);
    }
}
