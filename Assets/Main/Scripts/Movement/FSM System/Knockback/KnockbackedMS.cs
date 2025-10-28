using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObjectContextContainer))]
public class KnockbackedMS : MovementState
{
    public string knockbackVelocityContextKey = "KnockbackVelocity";
    public float gravityScale;
    private float initialGravity;
    private GameObjectContextContainer contextContainer;

    protected override void Awake()
    {
        base.Awake();

        contextContainer = GetComponent<GameObjectContextContainer>();
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

        Vector2 kbV = Vector2.zero;
        if (contextContainer != null &&
            contextContainer.context.TryGetValue(knockbackVelocityContextKey, out var value) &&
            value is Vector2 knockback)
        {
            kbV = knockback;
        }
        cc.rb.velocity = kbV;
    }

    protected override void Update()
    {
        base.Update();
    }

    private void FixedUpdate()
    {

    }
}
