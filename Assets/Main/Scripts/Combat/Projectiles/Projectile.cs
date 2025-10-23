using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;

    public LayerMask hittableLayers;
    public float damage = 1f;
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
        if (!collision.isTrigger &&
            LayerUtils.IsInLayerMask(collision.gameObject.layer, hittableLayers) &&
            collision.gameObject.TryGetComponent(out IHittable hittable))
        {
            hittable.Hit(1f);
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
}
