using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/Dialogue")]
public class DialogueSO : ScriptableObject
{
    public DialogueNodeSO initialNode;
    public bool ContainsQuest => ContainsQuestNode(initialNode);

    private bool ContainsQuestNode(DialogueNodeSO node)
    {
        if (node == null)
            return false;
        HashSet<DialogueNodeSO> visited = new();
        return DFS(node, visited);
    }

    private bool DFS(DialogueNodeSO node, HashSet<DialogueNodeSO> visited)
    {
        if (visited.Contains(node))
            return false;
        visited.Add(node);
        if (node is QuestDN)
            return true;
        foreach (var next in node.nextNodes)
        {
            if (DFS(next, visited))
                return true;
        }
        return false;
    }
}
