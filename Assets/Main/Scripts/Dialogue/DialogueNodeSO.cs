using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueNodeSO : ScriptableObject
{
    public DialogueCharacterSO speaker;
    public DialogueEmotion emotion = DialogueEmotion.Neutral;
    public string text;
    public DialogueNodeCondition condition;
    public List<DialogueNodeSO> nextNodes = new();
    public string focusObjectId;

    public DialogueNodeSO GetNextNode()
    {
        if (nextNodes.Count > 0)
        {
            foreach (DialogueNodeSO node in nextNodes)
            {
                if (node.EligibleForTransition())
                {
                    return node;
                }
            }
        }
        return null;
    }

    public bool EligibleForTransition()
    {
        return condition == null || condition.IsMet();
    }
}
