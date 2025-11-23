using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Requirement/Kill")]
public class KillQR : QuestRequirementSO
{
    public string trackedEnemyId;
    public string killedEnemyCounterContextKey;
    public int killAmountRequired;

    public override bool IsComplete()
    {
        return QuestSystem.Instance.GetContext<int>(killedEnemyCounterContextKey, 0) >= killAmountRequired;
    }

    public override void Register()
    {
        GlobalEvent.onEnemyKilled += TrackEnemy;
        QuestSystem.Instance.SetContext(killedEnemyCounterContextKey, 0);
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
                QuestSystem.Instance.GetContext<int>(killedEnemyCounterContextKey, 0) + 1);

            if (QuestSystem.Instance.GetContext<int>(killedEnemyCounterContextKey, 0) == killAmountRequired)
            {
                onCompleted?.Invoke();
            }
        }
    }
}
