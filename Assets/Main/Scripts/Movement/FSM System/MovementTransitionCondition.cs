using UnityEngine;

public abstract class MovementTransitionCondition : ScriptableObject
{
    [HideInInspector]
    public MovementBrain owner;

    public abstract bool IsMet(MovementBrain brain);
    public abstract void OnEnter();
    public abstract void OnExit();
}
