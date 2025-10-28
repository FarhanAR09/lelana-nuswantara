using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObjectContextContainer))]
[DefaultExecutionOrder(-2147483648)]
public class CharacterBrain : MonoBehaviour
{
    public List<CharacterState> states;
    public CharacterState activeState;
    private GameObjectContextContainer contextContainer;
    public Dictionary<string, object> Context
    {
        get => contextContainer.context;
        private set => contextContainer.context = value;
    }

    private void Awake()
    {
        contextContainer = GetComponent<GameObjectContextContainer>();
        GetComponents(states);

        if (activeState != null)
        {
            foreach (CharacterState state in states)
            {
                state.enabled = state == activeState;
            }
        }
    }

    public void ChangeState(CharacterState newState)
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
