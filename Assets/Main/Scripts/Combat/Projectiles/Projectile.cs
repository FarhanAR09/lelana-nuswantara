using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private WeaponContext weaponContext;

    public LayerMask hittableLayers;
    public float damage = 1f;
    public float knockbackDurationSec = 0.5f;
    public float destroyTime = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!LayerUtils.IsInLayerMask(collision.gameObject.layer, hittableLayers))
            return;

        if (collision.gameObject.TryGetComponent(out IHittable hittable))
        {
            hittable.Hit(1f);
            Destroy(gameObject);
        }

        if (collision.TryGetComponent(out IKnockbackable knockbackable))
        {
            Vector2 velocity = collision.transform.position - weaponContext.combatManager.transform.position;
            velocity.y = 10f;
            knockbackable.Knockback(velocity, knockbackDurationSec);
        }
    }

    public void Launch(Vector2 velocity, WeaponContext weaponContext)
    {
        rb.velocity = velocity;
        this.weaponContext = weaponContext;
    }
}
