using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerProximityDetector : MonoBehaviour
{
    public string id = "";
    public bool PlayerDetected { get; private set; } = false;
    public PlayerController DetectedPlayer { get; private set; }
    public CollisionEventHolder collisionEventHolder;

    private void OnEnable()
    {
        collisionEventHolder.onTriggerEnter2D += TriggerEnter2D;
        collisionEventHolder.onTriggerExit2D += TriggerExit2D;
    }

    private void OnDisable()
    {
        collisionEventHolder.onTriggerEnter2D -= TriggerEnter2D;
        collisionEventHolder.onTriggerExit2D -= TriggerExit2D;
    }

    private void TriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            PlayerDetected = true;
            DetectedPlayer = player;
        }
    }

    private void TriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            PlayerDetected = false;
            DetectedPlayer = null;
        }
    }
}
