using Assets.Character;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterStandingState : State
{
    public CharacterStandingState() : base()
    {
    }

    public override void HandleInput(Context context)
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            context.Gun.Fire(new BulletShotOptions());
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        if (movement != Vector2.zero)
        {
            context.ChangeState(new CharacterRunningState());
        }

        base.HandleInput(context);
    }
}
