using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Combat/Weapon Sequence")]
public class WeaponSequence : ScriptableObject
{
    public WeaponAction initialAction;
    public WeaponAction activeAction;
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
        this.context = context;
        var instantiating = activeAction != null ? activeAction : initialAction != null ? initialAction : null;
        if (instantiating != null)
        {
            activeAction = Instantiate(instantiating);
            activeAction.Initialize(this, context);
        }
    }

    public void ResetSequence()
    {
        ChangeAction(initialAction);
    }
}
