using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementContext : MonoBehaviour
{
    public bool isGrounded = true;

    private Dictionary<string, object> data = new();
    public UnityAction<string, object> onEventSent;

    public void Set<T>(string key, T value)
    {
        data[key] = value;
    }

    public T Get<T>(string key, T defaultValue = default)
    {
        if (data.TryGetValue(key, out var value) && value is T tValue)
            return tValue;
        return defaultValue;
    }

    public bool Has(string key) => data.ContainsKey(key);
}
