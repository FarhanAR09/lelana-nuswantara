using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueView : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] Image portraitDisplay;
    [SerializeField] TextMeshProUGUI nameDisplay, dialogueDisplay;
    [SerializeField] Button continueButton;

    DialogueNodeSO node;

    [Header("Debug")]
    [SerializeField] DialogueSO dialogue;

    private void Start()
    {
        StartDialogue(dialogue);
    }

    private void OnEnable()
    {
        continueButton.onClick.AddListener(ContinueDialogue);
    }

    private void OnDisable()
    {
        continueButton.onClick.RemoveListener(ContinueDialogue);
    }

    private void ContinueDialogue()
    {
        var newNode = node.GetNextNode();
        if (newNode == null)
        {
            dialoguePanel.SetActive(false);
            return;
        }
        node = newNode;

        UpdateDisplay(node);
    }

    public void StartDialogue(DialogueSO dialogueSO)
    {
        if (dialogueSO == null || dialogueSO.initialNode == null)
        {
            dialoguePanel.SetActive(false);
            return;
        }

        node = dialogueSO.initialNode;
        dialoguePanel.SetActive(true);
        UpdateDisplay(node);
    }

    private void UpdateDisplay(DialogueNodeSO node)
    {
        portraitDisplay.sprite = node.speaker.GetPortrait(node.emotion);
        nameDisplay.text = node.speaker.characterName;
        dialogueDisplay.text = node.text;
    }
}
