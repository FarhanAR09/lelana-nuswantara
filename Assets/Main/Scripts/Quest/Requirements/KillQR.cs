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
        Debug.Log("Kill Enemy Registered with " + trackedEnemyId);
    }

    public override void Unregister()
    {
        GlobalEvent.onEnemyKilled -= TrackEnemy;
    }

    private void TrackEnemy(EnemyData enemy)
    {
        Debug.Log("Enemy killed " + enemy.id + " " + QuestSystem.Instance.GetContext<int>(killedEnemyCounterContextKey, 0));
        if (enemy.id == trackedEnemyId)
        {
            Debug.Log("Matched");
            QuestSystem.Instance.SetContext(
                killedEnemyCounterContextKey,
                QuestSystem.Instance.GetContext<int>(killedEnemyCounterContextKey, 0) + 1);
            Debug.Log("Enemy counted " + enemy.id + " " + QuestSystem.Instance.GetContext<int>(killedEnemyCounterContextKey, 0));

            if (QuestSystem.Instance.GetContext<int>(killedEnemyCounterContextKey, 0) == killAmountRequired)
            {
                onCompleted?.Invoke();
            }
        }
    }
}
