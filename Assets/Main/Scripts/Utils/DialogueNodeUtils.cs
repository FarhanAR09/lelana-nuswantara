using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public static class DialogueNodeUtils
{
    public static DialogueNodeSO GetPrioritizedNode(this List<DialogueNodeSO> nodeList)
    {
        List<DialogueNodeSO> eligibleNodesWithConditions = new();
        List<DialogueNodeSO> eligibleNodesWithoutConditions = new();
        foreach (var node in nodeList)
        {
            if (node != null)
            {
                if (node.EligibleForTransition())
                {
                    if (node.condition == null)
                        eligibleNodesWithoutConditions.Add(node);
                    else
                        eligibleNodesWithConditions.Add(node);
                }
            }
        }
        //Prioritize nodes with condition
        DialogueNodeSO priorityNode = null;
        if (eligibleNodesWithConditions.Count > 0)
        {
            int priority = -2147483648;
            foreach (var node in eligibleNodesWithConditions)
            {
                if (node.priority >= priority)
                {
                    priority = node.priority;
                    priorityNode = node;
                }
            }
            return priorityNode;
        }
        if (eligibleNodesWithoutConditions.Count > 0)
        {
            int priority = -2147483648;
            foreach (var node in eligibleNodesWithoutConditions)
            {
                if (node.priority >= priority)
                {
                    priority = node.priority;
                    priorityNode = node;
                }
            }
            return priorityNode;
        }
        return null;
    }
}
