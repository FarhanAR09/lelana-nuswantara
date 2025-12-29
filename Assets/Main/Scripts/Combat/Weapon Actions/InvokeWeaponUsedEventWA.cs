using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New InvokeWeaponUsedEventWA", menuName = "Combat/Weapon Actions/InvokeWeaponUsedEventWA")]
public class InvokeWeaponUsedEventWA : WeaponAction
{
    public WeaponAction nextAction;
    public string stringArg;

    public override void OnEnter()
    {
        currentSequence.InvokeWeaponActionEvent(this, stringArg);
        currentSequence.ChangeAction(nextAction);
    }

    public override void OnExit()
    {
        
    }

    public override void OnPhysicsUpdate()
    {
        
    }

    public override void OnUpdate()
    {
        
    }
}
