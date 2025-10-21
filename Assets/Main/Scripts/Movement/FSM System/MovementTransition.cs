using System.Collections.Generic;

[System.Serializable]
public class MovementTransition
{
    public string name;
    public MovementState targetState;

    public List<MovementTransitionCondition> conditions;

    public bool CanTransition(MovementBrain brain)
    {
        foreach (var condition in conditions)
        {
            if (!condition.IsMet(brain))
                return false;
        }
        return true;
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