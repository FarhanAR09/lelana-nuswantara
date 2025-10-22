using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponContext
{
    public Vector2 aimDirection = Vector2.zero;
    public bool fireDown = false, fireIn = false, fireUp = false;

    private Dictionary<string, object> data = new();

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

    public void ResetInputs()
    {
        aimDirection = Vector2.zero;
        fireDown = false; fireIn = false; fireUp = false;
    }
}
