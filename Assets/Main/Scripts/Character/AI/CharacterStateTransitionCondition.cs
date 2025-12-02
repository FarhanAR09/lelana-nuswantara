using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Instantiated conditions for CharacterStateTransitions
/// </summary>
public abstract class CharacterStateTransitionCondition : ScriptableObject
{
    [HideInInspector]
    public CharacterBrain owner;

    public abstract bool IsMet(CharacterBrain brain);
    public abstract void OnEnter(CharacterBrain brain);
    public abstract void OnExit(CharacterBrain brain);
}
