using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterStateTransition
{
    public string name;
    public CharacterState targetState;

    public List<CharacterStateTransitionCondition> conditions;

    public void ResetConditions(CharacterBrain owner)
    {
        if (conditions.Count > 0)
        {
            for (int i = 0; i < conditions.Count; i++)
            {
                conditions[i] = ScriptableObject.Instantiate(conditions[i]);
                conditions[i].owner = owner;
            }
        }
    }

    public bool CanTransition(CharacterBrain brain)
    {
        if (conditions == null || conditions.Count == 0)
            return true;

        foreach (var condition in conditions)
        {
            if (condition.IsMet(brain))
                return true;
        }
        return false;
    }

    public void InvokeConditionsOnEnter(CharacterBrain brain)
    {
        foreach (var condition in conditions)
        {
            condition.OnEnter(brain);
        }
    }

    public void InvokeConditionsOnExit(CharacterBrain brain)
    {
        foreach (var condition in conditions)
        {
            condition.OnExit(brain);
        }
    }
}
