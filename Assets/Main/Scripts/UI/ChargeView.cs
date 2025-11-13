using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeView : MonoBehaviour
{
    public Slider slider;
    public CombatManager combatManager;

    public string chargeStateKey = "ChargeStateChange";

    private void OnEnable()
    {
        combatManager.WeaponContext.onEventSent +=
    }

    private void OnDisable()
    {
        
    }

    private void SetActiveSlider(string key, object args)
    {
        if (key != chargeStateKey)
            return;
        bool active = (bool)args;
    }
}
