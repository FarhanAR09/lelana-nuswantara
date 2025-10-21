using UnityEngine;

public abstract class MovementTransitionCondition : ScriptableObject
{
    public abstract bool IsMet(MovementBrain brain);
    public abstract void OnEnter();
    public abstract void OnExit();
}
