using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledMS : MovementState
{
    public float gravityScale;
    private float initialGravity;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        cc.rb.gravityScale = initialGravity;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        initialGravity = cc.rb.gravityScale;
        cc.rb.gravityScale = gravityScale;
    }

    protected override void Update()
    {
        base.Update();
    }

    private void FixedUpdate()
    {
        
    }
}
