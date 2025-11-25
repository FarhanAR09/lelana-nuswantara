using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Action/Turn In Quest")]
public class TurnInQuestActionSO : ActionSO
{
    public QuestSO turnInQuest;

    public override void Invoke(object args)
    {
        if (QuestSystem.Instance != null && turnInQuest != null)
        {
            QuestSystem.Instance.TurnInQuest(turnInQuest);
        }
    }
}
