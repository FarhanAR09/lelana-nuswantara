using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GameObjectContextContainer))]
[RequireComponent(typeof(CoroutineRunner))]
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
    public CoroutineRunner CoroutineRunner { get; private set; }

    private void Awake()
    {
        contextContainer = GetComponent<GameObjectContextContainer>();
        CoroutineRunner = GetComponent<CoroutineRunner>();
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

    public void Set<T>(string key, T value)
    {
        Context[key] = value;
    }

    public T Get<T>(string key, T defaultValue = default)
    {
        if (Context.TryGetValue(key, out var value) && value is T tValue)
            return tValue;
        return defaultValue;
    }

    public bool Has(string key) => Context.ContainsKey(key);
}
