using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/Dialogue")]
public class DialogueSO : ScriptableObject
{
    public List<DialogueNodeSO> initialNodes;
    public DialogueViewSettings dialogueViewSettingsOverride = null;
    public bool ContainsAvailableQuest
    {
        get
        {
            foreach (var node in initialNodes)
            {
                if (ContainsAvailableQuestNode(node))
                    return true;
            }
            return false;
        }
    }

    public DialogueNodeSO GetInitialNode()
    {
        return initialNodes.GetPrioritizedNode();
    }

    private bool ContainsAvailableQuestNode(DialogueNodeSO node)
    {
        if (node == null)
            return false;
        HashSet<DialogueNodeSO> visited = new();
        return DFS(node, visited);
    }

    private bool DFS(DialogueNodeSO node, HashSet<DialogueNodeSO> visited)
    {
        if (node == null)
            return false;

        if (visited.Contains(node))
            return false;
        visited.Add(node);
        if (node is QuestDN &&
            //Contains available quest
            (!QuestSystem.Instance.AllQuests.Contains(((QuestDN)node).quest) ||
            (QuestSystem.Instance.ReadyToTurnInQuests.Contains(((QuestDN)node).quest))))
            return true;

        if (node.NextNodes == null || node.NextNodes.Count == 0)
            return false;

        foreach (var next in node.NextNodes)
        {
            if (DFS(next, visited))
                return true;
        }
        return false;
    }
}
