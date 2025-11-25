using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Condition/QuestReadyToTurnIn")]
public class QuestReadyToTurnInDC : DialogueNodeCondition
{
    public QuestSO trackedQuest;

    public override bool IsMet()
    {
        return QuestSystem.Instance.ReadyToTurnInQuests.Contains(trackedQuest);
    }
}
