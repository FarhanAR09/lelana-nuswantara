using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(2147483647)]
[RequireComponent(typeof(CharacterBrain))]
public class CharacterState : MonoBehaviour
{
    public string id;
    protected CharacterBrain brain;

    public List<CharacterStateTransition> transitions;

    protected virtual void OnEnable()
    {
        foreach (var transition in transitions)
        {
            transition.InvokeConditionsOnEnter(brain);
        }
    }

    protected virtual void OnDisable()
    {
        foreach (var transition in transitions)
        {
            transition.InvokeConditionsOnExit(brain);
        }
    }

    protected virtual void Awake()
    {
        brain = GetComponent<CharacterBrain>();

        foreach (var transition in transitions)
        {
            transition.ResetConditions(brain);
        }
    }

    protected virtual void Update()
    {
        foreach (var transition in transitions)
        {
            if (transition.CanTransition(brain))
            {
                brain.ChangeState(transition.targetState);
            }
        }
    }
}
