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

    [Header("Dialogue View Settings")]
    [SerializeField] DialogueViewSettings defaultSettings;
    private DialogueViewSettings overrideSettings = null;
    private DialogueViewSettings CurrentSettings => overrideSettings ?? defaultSettings;
    private int originalCameraPriority = 0;

    [Header("Basic UI")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] Image portraitDisplay;
    [SerializeField] TextMeshProUGUI nameDisplay, dialogueDisplay;
    [SerializeField] Button continueButton;
    [SerializeField] CinemachineVirtualCamera dialogueCamera;

    [Header("Quest UI")]
    [SerializeField] GameObject questPanel;
    [SerializeField] Button acceptQuestButton;
    [SerializeField] Button declineQuestButton;

    DialogueNodeSO node;
    float originalTimeScale = 1f;

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

    private void ContinueDialogue()
    {
        continueButton.interactable = true;

        DialogueNodeSO newNode;
        if (node is QuestDN)
        {
            if (questAccepted)
                newNode = (node as QuestDN).GetAcceptNode();
            else
                newNode = (node as QuestDN).GetDeclineNode();
        }
        else
        {
            newNode = node.GetNextNode();
        }

        // Dialogue Finished
        if (newNode == null)
        {
            Time.timeScale = originalTimeScale;
            dialogueCamera.Priority = originalCameraPriority;

            dialoguePanel.SetActive(false);
            OnDialogueEnd.Invoke();
            return;
        }
        
        node = newNode;

        UpdateDisplay(node);
    }

    public void StartDialogue(DialogueSO dialogueSO)
    {
        if (dialogueSO.dialogueViewSettingsOverride != null)
        {
            overrideSettings = dialogueSO.dialogueViewSettingsOverride;
        }
        else
        {
            overrideSettings = null;
        }

        if (IsOpen)
        {
            return;
        }

        if (dialogueSO == null || dialogueSO.GetInitialNode() == null)
        {
            dialoguePanel.SetActive(false);
            Debug.LogWarning("dialogueSO == null || dialogueSO.initialNode == null");
            return;
        }

        node = dialogueSO.GetInitialNode();
        dialoguePanel.SetActive(true);
        UpdateDisplay(node);

        originalCameraPriority = dialogueCamera.Priority;
        dialogueCamera.Priority = CurrentSettings.activeCameraPriority;
        dialogueCamera.m_Lens.FieldOfView = CurrentSettings.cameraFov;
        
        originalTimeScale = Time.timeScale;
        Time.timeScale = CurrentSettings.timeScale;

        OnDialogueStart.Invoke();
    }

    private void UpdateDisplay(DialogueNodeSO node)
    {
        portraitDisplay.sprite = node.speaker.GetPortrait(node.emotion);
        nameDisplay.text = node.speaker.characterName;
        dialogueDisplay.text = node.text;
        continueButton.interactable = true;

        if (node is QuestDN dN)
        {
            questPanel.SetActive(true);
            declineQuestButton.gameObject.SetActive(!dN.forceAccept);
            continueButton.interactable = false;
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

        node.InvokeActionsOnInteract();
    }

    private bool questAccepted = false;
    private void AcceptQuest()
    {
        questAccepted = true;
        if (node is QuestDN)
        {
            (node as QuestDN).StartQuest();
        }
        ContinueDialogue();
    }

    private void DeclineQuest()
    {
        questAccepted = false;
        ContinueDialogue();
    }
}

[CreateAssetMenu(menuName = "Dialogue/View Settings")]
public class DialogueViewSettings : ScriptableObject
{
    public int activeCameraPriority = 10;
    public int cameraFov = 15;
    public float timeScale = 1f;
}
