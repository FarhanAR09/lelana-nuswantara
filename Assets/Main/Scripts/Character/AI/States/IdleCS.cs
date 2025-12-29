using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleCS : CharacterState
{
    public MovementBrain movementBrain;

    protected override void Awake()
    {
        base.Awake();

        if (movementBrain == null)
            movementBrain = GetComponent<MovementBrain>();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void Update()
    {
        base.Update();
        movementBrain.inputs.horizontal = 0f;
    }
}
