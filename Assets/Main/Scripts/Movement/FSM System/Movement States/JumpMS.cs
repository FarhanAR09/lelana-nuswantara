using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpMS : MovementState
{
    public float speed;
    private Rigidbody2D rb;
    private int jumpBufferFrames = 3;
    private int framesSinceJump;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void OnEnable()
    {
        rb.velocity = new Vector2(rb.velocity.x, 10f);
        framesSinceJump = 0;
    }

    private void FixedUpdate()
    {
        if (framesSinceJump < jumpBufferFrames)
        {
            framesSinceJump++;
            return;
        }

        Vector2 move = new(speed * brain.inputs.horizontal, 0f);
        if (cc.isGrounded)
        {
            move = Vector3.ProjectOnPlane(move, cc.groundNormal);
        }
        else
        {
            move.y = rb.velocity.y;
        }

        cc.SetVelocity(move);
    }
}
