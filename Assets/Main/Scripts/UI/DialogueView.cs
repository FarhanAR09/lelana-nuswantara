using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueView : Singleton<DialogueView>
{
    public bool IsOpen => dialoguePanel.activeInHierarchy;

    public UnityEvent OnDialogueStart { get; private set; } = new();
    public UnityEvent OnDialogueEnd { get; private set; } = new();

    [Header("Basic UI")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] Image portraitDisplay;
    [SerializeField] TextMeshProUGUI nameDisplay, dialogueDisplay;
    [SerializeField] Button continueButton;
    [SerializeField] CinemachineVirtualCamera dialogueCamera;
    [SerializeField] int activeCameraPriority = 10;
    private int originalCameraPriority = 0;

    [Header("Quest UI")]
    [SerializeField] GameObject questPanel;
    [SerializeField] Button acceptQuestButton;
    [SerializeField] Button declineQuestButton;

    DialogueNodeSO node;

    private void OnEnable()
    {
        continueButton.onClick.AddListener(ContinueDialogue);
        acceptQuestButton.onClick.AddListener(AcceptQuest);
        declineQuestButton.onClick.AddListener(DeclineQuest);
    }

    private void OnDisable()
    {
        continueButton.onClick.RemoveListener(ContinueDialogue);
        acceptQuestButton.onClick.RemoveListener(AcceptQuest);
        declineQuestButton.onClick.RemoveListener(DeclineQuest);
    }

    private void Start()
    {
        dialoguePanel.SetActive(false);
    }

    private void ContinueDialogue()
    {
        var newNode = node.GetNextNode();
        
        // Dialogue Finished
        if (newNode == null)
        {
            dialoguePanel.SetActive(false);
            dialogueCamera.Priority = originalCameraPriority;
            OnDialogueEnd.Invoke();
            return;
        }
        node = newNode;

        UpdateDisplay(node);
    }

    public void StartDialogue(DialogueSO dialogueSO)
    {
        if (IsOpen)
        {
            return;
        }

        if (dialogueSO == null || dialogueSO.initialNode == null)
        {
            dialoguePanel.SetActive(false);
            return;
        }

        node = dialogueSO.initialNode;
        dialoguePanel.SetActive(true);
        UpdateDisplay(node);

        originalCameraPriority = dialogueCamera.Priority;
        dialogueCamera.Priority = activeCameraPriority;

        OnDialogueStart.Invoke();
    }

    private void UpdateDisplay(DialogueNodeSO node)
    {
        portraitDisplay.sprite = node.speaker.GetPortrait(node.emotion);
        nameDisplay.text = node.speaker.characterName;
        dialogueDisplay.text = node.text;

        if (node is QuestDN)
        {
            questPanel.SetActive(true);
        }
        else
        {
            questPanel.SetActive(false);
        }

        if (node.focusObjectId != null && node.focusObjectId != "")
        {
            Transform focus = DialogueFocusLocator.Instance.FindFocusObject(node.focusObjectId);
            if (focus != null)
            {
                dialogueCamera.Follow = focus;
            }
        }
    }

    private void AcceptQuest()
    {
        if (node is QuestDN)
        {
            (node as QuestDN).StartQuest();
        }
        ContinueDialogue();
    }

    private void DeclineQuest()
    {
        ContinueDialogue();
    }
}
