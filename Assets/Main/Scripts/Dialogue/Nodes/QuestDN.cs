using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Node/Quest", fileName = "Quest Node")]
public class QuestDN : DialogueNodeSO
{
    public QuestSO quest;
    public bool forceAccept = false;

    public List<DialogueNodeSO> acceptNodes, declineNodes;

    public override List<DialogueNodeSO> NextNodes
    {
        get => base.NextNodes.Append(GetAcceptNode()).Append(GetDeclineNode()).ToList();
        protected set => nextNodes = value;
    }

    public void StartQuest()
    {
        if (QuestSystem.Instance != null)
        {
            QuestSystem.Instance.AddToActiveQuest(quest);
        }
    }

    public DialogueNodeSO GetAcceptNode()
    {
        if (acceptNodes.Count > 0)
        {
            foreach (DialogueNodeSO node in acceptNodes)
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

    public DialogueNodeSO GetDeclineNode()
    {
        if (declineNodes.Count > 0)
        {
            foreach (DialogueNodeSO node in declineNodes)
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
}
