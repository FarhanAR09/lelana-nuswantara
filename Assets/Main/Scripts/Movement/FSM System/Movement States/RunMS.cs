using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RunMS : MovementState
{
    private Rigidbody2D rb;

    public float speed;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
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
            move.y = rb.velocity.y;
        }
        cc.SetVelocity(move);
    }
}
