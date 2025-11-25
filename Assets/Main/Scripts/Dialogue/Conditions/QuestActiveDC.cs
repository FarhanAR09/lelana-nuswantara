using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Condition/Quest Active")]
public class QuestActiveDC : DialogueNodeCondition
{
    public QuestSO trackedQuest;

    public override bool IsMet()
    {
        return QuestSystem.Instance.ActiveQuests.Contains(trackedQuest);
    }
}
