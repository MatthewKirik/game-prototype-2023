using Assets.Character;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterRunningState : State
{
    public CharacterRunningState() : base()
    {
    }

    public override void HandleInput(Context context)
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            context.Gun.Fire(new BulletShotOptions()
            {
                Accuracy = 0.8f,
            });
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool sprinting = Input.GetKey(KeyCode.LeftShift);

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        if (sprinting)
        {
            context.ChangeState(new CharacterSprintingState());
        }
        else if (movement == Vector2.zero)
        {
            context.ChangeState(new CharacterStandingState());
        }

        base.HandleInput(context);
    }
}
