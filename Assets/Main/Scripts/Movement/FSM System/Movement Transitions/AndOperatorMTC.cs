using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement/Conditions/Operator And")]
public class AndOperatorMTC : MovementTransitionCondition
{
    public List<MovementTransitionCondition> conditions;

    public override bool IsMet(MovementBrain brain)
    {
        foreach (MovementTransitionCondition condition in conditions)
        {
            if (!condition.IsMet(brain))
                return false;
        }
        return true;
    }

    public override void OnEnter()
    {
        
    }

    public override void OnExit()
    {
        
    }
}
