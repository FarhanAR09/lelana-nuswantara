using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCS : CharacterState
{
    [field: SerializeField]
    public string TargetContextKey { get; private set; }
    public Transform target;
    public MovementBrain movementBrain;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        if (TargetContextKey != null && TargetContextKey.Length > 0)
        {
            if (brain.Context.ContainsKey(TargetContextKey) &&
                brain.Context[TargetContextKey] != null &&
                brain.Context[TargetContextKey] is Transform)
            {
                target = brain.Context[TargetContextKey] as Transform;
            }
        }
    }

    protected override void Update()
    {
        base.Update();
        if (target != null)
        {
            movementBrain.inputs.horizontal = (target.position - transform.position).normalized.x;
        }
    }
}
