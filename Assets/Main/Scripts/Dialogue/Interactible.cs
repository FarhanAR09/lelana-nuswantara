using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{
    [SerializeField] DialogueSO dialogue;
    [SerializeField] Image iconImage, questIconImage;

    private void Start()
    {
        ChangeIconVisibility(false);
    }

    public void Interact()
    {
        if (DialogueView.Instance != null && dialogue != null)
        {
            DialogueView.Instance.StartDialogue(dialogue);
        }
    }

    public void ChangeIconVisibility(bool state)
    {
        iconImage.gameObject.SetActive(state);

        questIconImage.gameObject.SetActive(false);
        if (dialogue.ContainsQuest)
        {
            questIconImage.gameObject.SetActive(!state);
        }
    }
}
