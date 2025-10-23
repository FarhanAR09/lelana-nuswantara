using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour, IHittable
{
    public Health health;

    public HitResult Hit(float damage)
    {
        health.TakeDamage(damage);
        return new HitResult();
    }
}
