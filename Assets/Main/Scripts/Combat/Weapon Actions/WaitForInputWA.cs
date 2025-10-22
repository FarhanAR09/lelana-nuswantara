using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Weapon Actions/Wait For Input")]
public class WaitForInputWA : WeaponAction
{
    public WeaponAction nextAction;
    public WeaponInputType inputType = WeaponInputType.FireDown;

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
        if (CheckInput())
        {
            currentSequence.ChangeAction(nextAction);
        }
    }

    private bool CheckInput()
    {
        return inputType switch
        {
            WeaponInputType.FireUp => context.fireUp,
            WeaponInputType.FireDown => context.fireDown,
            WeaponInputType.FireAltDown => context.fireAltDown,
            WeaponInputType.FireAltUp => context.fireAltUp,
            _ => false,
        };
    }
}

public enum WeaponInputType
{
    FireUp,
    FireDown,
    FireAltDown,
    FireAltUp
}
