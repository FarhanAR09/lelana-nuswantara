using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStateTransitionCondition : ScriptableObject
{
    [HideInInspector]
    public CharacterBrain owner;

    public abstract bool IsMet(CharacterBrain brain);
    public abstract void OnEnter();
    public abstract void OnExit();
}
