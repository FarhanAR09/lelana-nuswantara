using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LogInputsWA", menuName = "Combat/Weapon Actions/LogInputsWA")]
public class LogInputsWA : WeaponAction
{
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
        if (context.fireIn)
        {
            Debug.Log($"{name}: Fired");
        }
    }
}
