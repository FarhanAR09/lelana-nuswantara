using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Condition/Quest Completed")]
public class QuestCompletedDC : DialogueNodeCondition
{
    public QuestSO trackedQuest;

    public override bool IsMet()
    {
        return QuestSystem.Instance.CompletedQuests.Contains(trackedQuest);
    }
}
