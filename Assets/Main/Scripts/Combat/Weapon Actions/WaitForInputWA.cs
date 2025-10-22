using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Weapon Actions/Wait For Input")]
public class WaitForInputWA : WeaponAction
{
    public WeaponAction nextAction;

    public override void OnEnter()
    {
        
    }

    public override void OnExit()
    {
        
    }

    public override void OnPhysicsUpdate()
    {
        
    }

    public override void OnUpdate()
    {
        if (context.fireUp)
        {
            currentSequence.ChangeAction(nextAction);
        }
    }
}
