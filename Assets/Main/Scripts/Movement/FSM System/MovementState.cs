using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(2147483647)]
[RequireComponent(typeof(CharacterController2D))]
[RequireComponent(typeof(MovementBrain))]
public class MovementState : MonoBehaviour
{
    protected CharacterController2D cc;
    protected MovementBrain brain;
    
    public List<MovementTransition> transitions;
    public UnityAction onEnter, onExit;

    protected virtual void OnEnable()
    {
        foreach (var transition in transitions)
        {
            transition.InvokeConditionsOnEnter();
        }
        onEnter?.Invoke();
    }

    protected virtual void OnDisable()
    {
        foreach (var transition in transitions)
        {
            transition.InvokeConditionsOnExit();
        }
        onExit?.Invoke();
    }

    protected virtual void Awake()
    {
        cc = GetComponent<CharacterController2D>();
        brain = GetComponent<MovementBrain>();

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
