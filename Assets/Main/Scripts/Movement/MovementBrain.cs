using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-2147483648)]
[RequireComponent(typeof(CharacterController2D))]
public class MovementBrain : MonoBehaviour
{
    //Inputs
    public MovementInputs inputs = new();

    public List<MovementState> states;
    public MovementState activeState;
    public CharacterController2D cc;

    private void Awake()
    {
        GetComponents(states);

        if (activeState != null)
        {
            foreach (MovementState state in states)
            {
                state.enabled = state == activeState;
            }
        }

        cc = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        inputs.ResetInputs();
    }

    public void ChangeState(MovementState newState)
    {
        if (!states.Contains(newState))
        {
            Debug.LogWarning("State " + newState + " does not exist in brain's states list");
            return;
        }

        activeState.enabled = false;
        activeState = newState;
        newState.enabled = true;
    }
}
