using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float health = 100f;
    public UnityAction<float> onHealthChanged;
    public UnityAction onDie;

    public void Heal(float amount)
    {
        health += amount;
        onHealthChanged?.Invoke(health);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        onHealthChanged?.Invoke(health);
        if (health <= 0f)
            Kill();
    }

    public void Kill()
    {
        health = 0f;
        onDie?.Invoke();
    }
}
