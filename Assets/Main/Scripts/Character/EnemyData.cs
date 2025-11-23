using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyData : MonoBehaviour, IHittable
{
    public string id;
    public Health health;

    private void OnEnable()
    {
        health.onDie += Kill;
    }

    private void OnDisable()
    {
        health.onDie -= Kill;
    }

    public HitResult Hit(float damage)
    {
        health.TakeDamage(damage);
        return new HitResult();
    }

    private void Kill()
    {
        GlobalEvent.onEnemyKilled?.Invoke(this);
        Destroy(gameObject);
    }
}
