using UnityEngine;

public abstract class WeaponAction : ScriptableObject
{
    protected WeaponSequence currentSequence;
    protected WeaponContext context;

    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnPhysicsUpdate();
    public abstract void OnExit();

    public void ChangeState(WeaponAction newAction)
    {
        currentSequence.ChangeAction(newAction);
    }

    public void Initialize(WeaponSequence sequence, WeaponContext context)
    {
        this.currentSequence = sequence;
        this.context = context;
    }
}
