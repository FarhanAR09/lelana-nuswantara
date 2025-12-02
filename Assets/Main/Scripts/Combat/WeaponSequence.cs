using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Combat/Weapon Sequence")]
public class WeaponSequence : ScriptableObject
{
    public WeaponAction initialAction;
    public WeaponAction activeAction;
    /// <summary>
    /// Leave null if you don't want to cancel
    /// </summary>
    public WeaponAction cancelWeaponAction;
    private WeaponContext context;

    public UnityAction<WeaponAction> onWeaponActionChanged;

    public void ChangeAction(WeaponAction newActionData)
    {
        if (newActionData == null)
        {
            return;
        }

        if (activeAction != null)
            activeAction.OnExit();
        activeAction = Instantiate(newActionData);
        activeAction.Initialize(this, context);
        activeAction.OnEnter();

        onWeaponActionChanged?.Invoke(activeAction);
    }

    public void Update()
    {
        if (activeAction != null)
            activeAction.OnUpdate();
    }

    public void PhysicsUpdate()
    {
        if (activeAction != null)
            activeAction.OnPhysicsUpdate();
    }

    public void Initialize(WeaponContext context)
    {
        if (this.context != null)
            this.context.onAttackCancelled -= CancelAttack;

        this.context = context;
        var instantiating = activeAction != null ? activeAction : initialAction != null ? initialAction : null;
        if (instantiating != null)
        {
            activeAction = Instantiate(instantiating);
            activeAction.Initialize(this, context);
        }

        this.context.onAttackCancelled += CancelAttack;
    }

    public void ResetSequence()
    {
        ChangeAction(initialAction);
    }

    private void CancelAttack()
    {
        if (cancelWeaponAction != null)
        {
            ChangeAction(cancelWeaponAction);
        }
    }
}
