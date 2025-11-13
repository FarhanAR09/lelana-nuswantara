using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEventHolder : MonoBehaviour
{
    public UnityAction<Collider2D> onTriggerEnter2D, onTriggerStay2D, onTriggerExit2D;
    public UnityAction<Collision2D> onCollisionEnter2D, onCollisionStay2D, onCollisionExit2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEnter2D?.Invoke(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        onTriggerStay2D?.Invoke(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onTriggerExit2D?.Invoke(collision);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onCollisionEnter2D?.Invoke(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        onCollisionStay2D?.Invoke(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onCollisionExit2D?.Invoke(collision);
    }
}
