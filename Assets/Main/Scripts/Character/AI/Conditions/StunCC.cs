using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StunCC", menuName = "Character/Conditions/StunCC", order = 1)]
public class StunCC : CharacterStateTransitionCondition
{
    private KnockbackableExtension knockbackableExtension;

    public override bool IsMet(CharacterBrain brain)
    {
        if (knockbackableExtension == null)
        {
            knockbackableExtension = owner.GetComponent<KnockbackableExtension>();
        }

        if (knockbackableExtension != null)
        {
            return knockbackableExtension.IsKnockbacked;
        }
        return false;
    }

    public override void OnEnter(CharacterBrain brain)
    {
        knockbackableExtension = owner.GetComponent<KnockbackableExtension>();
    }

    public override void OnExit(CharacterBrain brain)
    {
        
    }
}
