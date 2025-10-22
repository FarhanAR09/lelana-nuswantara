using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Weapon Actions/Fire")]
public class FireWA : WeaponAction
{
    public WeaponAction actionAfterFire;
    public bool charged = false;
    public string chargeContextKey = "";
    public float duration = 0.5f;

    private float timer = 0f;

    public override void OnEnter()
    {
        timer = 0f;
        
        if (charged)
        {
            Debug.Log(name + " Charged Fire!!! " + context.Get<float>(chargeContextKey));
        }
        else
        {
            Debug.Log(name + " Fire!!!");
        }
    }

    public override void OnExit()
    {
        
    }

    public override void OnPhysicsUpdate()
    {
        
    }

    public override void OnUpdate()
    {
        if (timer < duration)
        {
            timer += Time.deltaTime;
        }
        else
        {
            currentSequence.ChangeAction(actionAfterFire);
        }
    }
}
