using UnityEngine;

public class JumpMS : MovementState
{
    public float speed;
    public float gravityScale = -9.81f;

    private int jumpBufferFrames = 3;
    private int framesSinceJump;
    private float initialGravity;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        cc.rb.velocity = new Vector2(cc.rb.velocity.x, 10f);
        initialGravity = cc.rb.gravityScale;
        cc.rb.gravityScale = gravityScale;
        framesSinceJump = 0;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        cc.rb.gravityScale = initialGravity;
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
            move.y = cc.rb.velocity.y;
        }

        cc.SetVelocity(move);
    }
}
