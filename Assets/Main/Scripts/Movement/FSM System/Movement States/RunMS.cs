using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RunMS : MovementState
{
    public float speed;
    public float gravityScale;

    private float initialGravity;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        
        initialGravity = cc.rb.gravityScale;
        cc.rb.gravityScale = gravityScale;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        cc.rb.gravityScale = initialGravity;
    }

    protected void FixedUpdate()
    {
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
