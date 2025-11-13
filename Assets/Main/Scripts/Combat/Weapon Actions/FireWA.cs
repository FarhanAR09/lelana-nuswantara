using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Weapon Actions", fileName = "Fire")]
public class FireWA : WeaponAction
{
    public WeaponAction actionAfterFire;
    public bool charged = false;
    public string chargeContextKey = "";
    public float duration = 0.5f;
    public Projectile projectilePrefab;
    public float projectileSpeed;

    private float timer = 0f;

    public override void OnEnter()
    {
        timer = 0f;

        //if (charged)
        //{
        //    Debug.Log(name + " Charged Fire!!! " + context.Get<float>(chargeContextKey) + " " + context.aimDirection);
        //}
        //else
        //{
        //    Debug.Log(name + " Fire!!!" + " " + context.aimDirection);
        //}
        if (projectilePrefab != null)
        {
            var projectile = Instantiate(projectilePrefab, context.combatManager.transform.position, Quaternion.identity);
            projectile.Launch(projectileSpeed * context.aimDirection, context);
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
