using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement/Conditions/Y Velocity", fileName = "Y Velocity")]
public class YVelocityMTC : MovementTransitionCondition
{
    public ComparisonType comparisonType;
    public float value = 0f;

    public override bool IsMet(MovementBrain brain)
    {
        return comparisonType switch
        {
            ComparisonType.Equal => brain.cc.rb.velocity.y == value,
            ComparisonType.GreaterThan => brain.cc.rb.velocity.y > value,
            ComparisonType.LessThan => brain.cc.rb.velocity.y < value,
            _ => false,
        };
    }

    public override void OnEnter()
    {
        
    }

    public override void OnExit()
    {
        
    }

    public enum ComparisonType
    {
        Equal,
        GreaterThan,
        LessThan
    }
}
