using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class WeaponContext
{
    public CombatManager combatManager;
    public Vector2 aimDirection = Vector2.zero;
    public bool fireDown = false, fireIn = false, fireUp = false;
    public bool fireAltDown = false, fireAltIn = false, fireAltUp = false;
    public bool cancelDown = false, cancelIn = false, cancelUp = false;

    private Dictionary<string, object> data = new();
    public UnityAction<string, object> onEventSent;

    public UnityAction onAttackCancelled;

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
        fireAltDown = false; fireAltIn = false; fireAltUp = false;
        cancelDown = false; cancelIn = false; cancelUp = false;
    }

    public void CancelAttack()
        => onAttackCancelled?.Invoke();
}
