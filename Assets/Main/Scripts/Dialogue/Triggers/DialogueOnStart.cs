using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(9999)]
public class DialogueOnStart : MonoBehaviour
{
    [SerializeField] DialogueSO dialogue;

    private void Start()
    {
        DialogueView.Instance.StartDialogue(dialogue);
    }
}
