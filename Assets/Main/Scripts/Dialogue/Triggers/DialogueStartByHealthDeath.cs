using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStartByHealthDeath : MonoBehaviour
{
    public DialogueSO dialogue;
    public Health targetHealth;
    public bool onlyOnce = true;
    private bool hasTriggered = false;

    private void OnEnable()
    {
        targetHealth.onDie += StartDialogue;
    }

    private void OnDisable()
    {
        targetHealth.onDie -= StartDialogue;
    }

    private void StartDialogue()
    {
        if (onlyOnce && hasTriggered) return;
        hasTriggered = true;
        DialogueView.Instance.StartDialogue(dialogue);
    }
}
