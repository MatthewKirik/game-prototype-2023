using Assets.Character;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 5f;
    public float sprintMultiplier = 1.5f;
    private Animator animator;

    public Context movementContext;

    public bool IsMirrored { get; private set; }

    private void Start()
    {
        animator = GetComponent<Animator>();

        var gun = GetComponentInChildren<GunController>();

        movementContext = new(new CharacterStandingState(), gun);
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool sprinting = Input.GetKey(KeyCode.LeftShift);

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        float speedMultiplier = sprinting ? sprintMultiplier : 1f;

        transform.Translate(movement * speed * Time.deltaTime * speedMultiplier);

        SetAnimation(horizontal, vertical, speedMultiplier);

        movementContext.HandleInput();
    }

    void SetAnimation(float xMovement, float yMovement, float speed)
    {
        bool moving = xMovement != 0 || yMovement != 0;
        animator.SetBool("Moving", moving);
        animator.speed = speed;

        if (xMovement != 0)
        {
            int xDirection = xMovement >= 0 ? 1 : -1;
            IsMirrored = xDirection == -1;
            gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x) * (xDirection), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }
}