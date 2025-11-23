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
    public virtual List<DialogueNodeSO> NextNodes
    {
        get { return nextNodes; }
        protected set { nextNodes = value; }
    }
    public string focusObjectId;
    public ActionSO actionOnInteract;

    public virtual DialogueNodeSO GetNextNode()
    {
        if (NextNodes.Count > 0)
        {
            foreach (DialogueNodeSO node in NextNodes)
            {
                if (node == null)
                    continue;
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
