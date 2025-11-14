using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Requirement/Kill")]
public class KillQR : QuestRequirementSO
{
    public string trackedEnemyId;
    public string killedEnemyCounterContextKey;

    public override bool IsComplete()
    {
        throw new System.NotImplementedException();
    }

    public override void Register()
    {
        GlobalEvent.onEnemyKilled += TrackEnemy;
    }

    public override void Unregister()
    {
        GlobalEvent.onEnemyKilled -= TrackEnemy;
    }

    private void TrackEnemy(EnemyData enemy)
    {
        if (enemy.id == trackedEnemyId)
        {
            QuestSystem.Instance.SetContext(
                killedEnemyCounterContextKey,
                QuestSystem.Instance.GetContext<int>(killedEnemyCounterContextKey + 1, 0));
        }
    }
}
