using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeView : MonoBehaviour
{
    public Slider slider;
    public CombatManager combatManager;

    public string chargeAmountKey;
    public string chargeStateKey = "ChargeStateChange";

    private void OnEnable()
    {
        combatManager.WeaponContext.onEventSent += SetActiveSlider;

        SetActiveSlider(chargeStateKey, false);
    }

    private void OnDisable()
    {
        combatManager.WeaponContext.onEventSent -= SetActiveSlider;
    }

    private void Update()
    {
        if (slider.gameObject.activeInHierarchy && chargeAmountKey != "")
        {
            slider.value = combatManager.WeaponContext.Get<float>(chargeAmountKey, 0f);
        }
    }

    private void SetActiveSlider(string key, object args)
    {
        if (key != chargeStateKey)
            return;
        try
        {
            bool active = (bool)args;
            slider.gameObject.SetActive(active);
        }
        catch
        {
            return;
        }
    }
}
