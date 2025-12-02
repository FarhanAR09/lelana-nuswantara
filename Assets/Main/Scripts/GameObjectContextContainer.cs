using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectContextContainer : MonoBehaviour
{
    public Dictionary<string, object> context = new();

    public void Set<T>(string key, T value)
    {
        context[key] = value;
    }

    public T Get<T>(string key, T defaultValue = default)
    {
        if (context.TryGetValue(key, out var value) && value is T tValue)
            return tValue;
        return defaultValue;
    }

    public bool Has(string key) => context.ContainsKey(key);
}
