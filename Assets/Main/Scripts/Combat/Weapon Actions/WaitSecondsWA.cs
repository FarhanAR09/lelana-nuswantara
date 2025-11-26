using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitSecondsWA : WeaponAction
{
    public override void OnEnter()
    {
        context.combatManager.Run
    }

    public override void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public override void OnPhysicsUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}
