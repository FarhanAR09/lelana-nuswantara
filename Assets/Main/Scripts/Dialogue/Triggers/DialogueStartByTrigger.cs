using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogueStartByTrigger : MonoBehaviour
{
    public DialogueSO dialogue;
    public bool destroyOnTrigger = false;

    public LayerMask layerMask;
    public List<Tag> tags = new();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerUtils.IsInLayerMask(collision.gameObject.layer, layerMask) && TagUtils.HasTag(collision.gameObject.tag, tags))
            if (dialogue != null && DialogueView.Instance != null)
                DialogueView.Instance.StartDialogue(dialogue);

        Destroy(gameObject);
    }
}
