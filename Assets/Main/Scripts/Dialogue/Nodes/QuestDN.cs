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
        if (acceptNodes != null)
        {
            return acceptNodes.GetPrioritizedNode();
        }
        return null;
    }

    public DialogueNodeSO GetDeclineNode()
    {
        if (declineNodes != null)
        {
            return declineNodes.GetPrioritizedNode();
        }
        return null;
    }
}
