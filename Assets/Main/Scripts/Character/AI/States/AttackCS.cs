using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCS : CharacterState
{
    [SerializeField] CombatManager combatManager;
    private Coroutine attackCoroutine;
    public float stateDuration = 1f;
    public CharacterState nextState;

    protected override void Update()
    {
        base.Update();
        combatManager.WeaponContext.fireDown = true;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        if (attackCoroutine != null)
            StopCoroutine(attackCoroutine);
        attackCoroutine = StartCoroutine(Attack());
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        combatManager.WeaponContext.fireDown = false;
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(stateDuration);
        brain.ChangeState(nextState);
    }
}
