using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStartByHealthEvent : MonoBehaviour
{
    public Health targetHealth;
    public DialogueSO dialogue;
    public bool onlyOnce = true;
    private bool hasTriggered = false;

    private void OnEnable()
    {
        targetHealth.onHealthChanged += StartDialogue;
    }

    private void OnDisable()
    {
        targetHealth.onHealthChanged -= StartDialogue;
    }

    private void StartDialogue(float _)
    {
        if (onlyOnce && hasTriggered) return;
        hasTriggered = true;
        DialogueView.Instance.StartDialogue(dialogue);
    }
}
