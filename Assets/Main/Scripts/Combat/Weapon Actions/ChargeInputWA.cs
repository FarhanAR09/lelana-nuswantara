using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Weapon Actions/Charge Input")]
public class ChargeInputWA : WeaponAction
{
    public WeaponAction nextAction;
    public WeaponInputType startChargeInput, endChargeInput;

    private bool isCharging = false;
    public string chargeContextKey;
    public float chargeDurationMax;
    private float chargeDuration;

    public override void OnEnter()
    {
        isCharging = false;
        chargeDuration = 0f;
    }

    public override void OnExit()
    {
        
    }

    public override void OnPhysicsUpdate()
    {
        
    }

    public override void OnUpdate()
    {
        if (!isCharging && CheckInput(startChargeInput))
        {
            isCharging = true;
        }
        if (isCharging && CheckInput(endChargeInput))
        {
            isCharging = false;
            context.Set<float>(chargeContextKey, chargeDuration / chargeDurationMax);
            currentSequence.ChangeAction(nextAction);
        }

        if (isCharging)
        {
            chargeDuration = Mathf.Clamp(chargeDuration + Time.deltaTime, 0f, chargeDurationMax);
        }
    }

    private bool CheckInput(WeaponInputType inputType)
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
