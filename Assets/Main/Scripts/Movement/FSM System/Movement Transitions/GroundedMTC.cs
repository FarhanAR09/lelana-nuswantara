using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement/Conditions/Grounded")]
public class GroundedMTC : MovementTransitionCondition
{
    public bool isGrounded;

    public override bool IsMet(MovementBrain brain)
    {
        return isGrounded == brain.cc.isGrounded;
    }

    public override void OnEnter()
    {
        
    }

    public override void OnExit()
    {
        
    }
}
