using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(DialogueFocusObject))]
public class Interactible : MonoBehaviour
{
    [SerializeField] DialogueSO dialogue;
    private Image iconImage, questIconImage;
    [SerializeField] Canvas interactibleCanvasPrefab;
    private Canvas interactibleCanvas;
    [SerializeField]
    public string InteractibleId { get; private set; }

    private void Awake()
    {
        if (interactibleCanvasPrefab != null)
        {
            interactibleCanvas = Instantiate(interactibleCanvasPrefab, transform);
            Transform foundInteractibleImage = interactibleCanvas.transform.Find("Interactible Icon");
            if (foundInteractibleImage != null && foundInteractibleImage.TryGetComponent<Image>(out Image interactibleImage))
            {
                iconImage = interactibleImage;
            }
            Transform foundQuestImage = interactibleCanvas.transform.Find("Quest Icon");
            if (foundQuestImage != null && foundQuestImage.TryGetComponent<Image>(out Image questImage))
            {
                questIconImage = questImage;
            }
        }
    }

    private void Start()
    {
        ChangeIconVisibility(false);
    }

    public void Interact()
    {
        if (DialogueView.Instance != null)
        {
            if (dialogue != null)
            {
                DialogueView.Instance.StartDialogue(dialogue);
            }
            else
            {
                Debug.LogWarning("Dialogue is null");
            }
        }
        GlobalEvent.onInteractibleInteracted?.Invoke(this);
    }

    public void ChangeIconVisibility(bool state)
    {
        iconImage.gameObject.SetActive(state);

        questIconImage.gameObject.SetActive(false);
        if (dialogue.ContainsAvailableQuest)
        {
            questIconImage.gameObject.SetActive(!state);
        }
    }
}

public static partial class GlobalEvent
{
    public static UnityAction<Interactible> onInteractibleInteracted;
}
