using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Weapon Sequence")]
public class WeaponSequence : ScriptableObject
{
    public WeaponAction activeAction;
    public List<WeaponAction> actions;

    public void ChangeAction(WeaponAction newAction)
    {
        if (newAction == null)
        {
            return;
        }

        if (actions.Contains(newAction) == false)
        {
            Debug.LogWarning("Tried to change to an action that doesn't exist in weapon sequence.");
            return;
        }
        if (activeAction != null)
            activeAction.OnExit();
        activeAction = newAction;
        activeAction.OnEnter();
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
        foreach (var action in actions)
        {
            action.Initialize(this, context);
        }
    }
}
