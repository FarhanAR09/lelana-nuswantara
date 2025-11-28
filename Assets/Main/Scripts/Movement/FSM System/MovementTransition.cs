using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
public class MovementTransition
{
    public string name;
    public MovementState targetState;

    /// <summary>
    /// OR condition operations
    /// </summary>
    public List<MovementTransitionCondition> conditions;

    public void ResetConditions(MovementBrain owner)
    {
        for (int i = 0; i < conditions.Count; i++)
        {
            conditions[i] = ScriptableObject.Instantiate(conditions[i]);
            conditions[i].owner = owner;
        }
    }

    public bool CanTransition(MovementBrain brain)
    {
        foreach (var condition in conditions)
        {
            if (condition.IsMet(brain))
                return true;
        }
        return false;
    }

    public void InvokeConditionsOnEnter()
    {
        foreach (var condition in conditions)
        {
            condition.OnEnter();
        }
    }

    public void InvokeConditionsOnExit()
    {
        foreach (var condition in conditions)
        {
            condition.OnExit();
        }
    }
}