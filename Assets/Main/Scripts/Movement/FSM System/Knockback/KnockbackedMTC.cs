using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement/Condition", fileName = "Knockbacked")]
public class KnockbackedMTC : MovementTransitionCondition
{
    private KnockbackableExtension knockbackableExtension;

    private bool isKnockbacked = false;

    public override bool IsMet(MovementBrain brain)
    {
        return isKnockbacked;
    }

    public override void OnEnter()
    {
        isKnockbacked = false;

        if (knockbackableExtension == null)
        {
            knockbackableExtension = owner.GetComponent<KnockbackableExtension>();
        }

        if (knockbackableExtension != null)
        {
            knockbackableExtension.onKnockbacked += SetKnockbackedState;
        }
    }

    public override void OnExit()
    {
        isKnockbacked = false;

        if (knockbackableExtension != null)
        {
            knockbackableExtension.onKnockbacked -= SetKnockbackedState;
        }
    }

    private void SetKnockbackedState()
    {
        isKnockbacked = true;
    }
}
