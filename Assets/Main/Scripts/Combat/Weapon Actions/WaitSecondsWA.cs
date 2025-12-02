using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaitSeconds", menuName = "Combat/Weapon Actions/Wait Seconds")]
public class WaitSecondsWA : WeaponAction
{
    [Tooltip("Key for CoroutineRunner in CombatManager (Weapon User GameObject Specific)")]
    public string coroutineKey = "WaitSeconds";
    public float duration = 1f;
    public WeaponAction nextAction;

    public override void OnEnter()
    {
        context.combatManager.CoroutineRunner.StopSingleCoroutine(coroutineKey);
        context.combatManager.CoroutineRunner.StartSingleCoroutine(coroutineKey, WaitSeconds());
    }

    public override void OnExit()
    {
        context.combatManager.CoroutineRunner.StopSingleCoroutine(coroutineKey);
    }

    public override void OnPhysicsUpdate()
    {
        
    }

    public override void OnUpdate()
    {
        
    }

    private IEnumerator WaitSeconds()
    {
        float start = Time.time;
        while (Time.time - start < duration)
        {
            yield return null;
        }
        currentSequence.ChangeAction(nextAction);
    }
}
