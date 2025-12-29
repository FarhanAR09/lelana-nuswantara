using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Health health;

    private void OnEnable()
    {
        health.onHealthChanged += UpdateUI;
    }

    private void OnDisable()
    {
        health.onHealthChanged -= UpdateUI;
    }

    private void UpdateUI(float _)
    {
        slider.value = health.health / health.maxHealth;
    }
}
