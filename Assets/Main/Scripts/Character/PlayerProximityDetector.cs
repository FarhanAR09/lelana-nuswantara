using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerProximityDetector : MonoBehaviour
{
    public bool PlayerDetected { get; private set; } = false;
    public PlayerController DetectedPlayer { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            PlayerDetected = true;
            DetectedPlayer = player;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            PlayerDetected = false;
            DetectedPlayer = null;
        }
    }
}
