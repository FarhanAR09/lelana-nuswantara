using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GlobalEvent
{
    /// <summary>
    /// Invoked when a global event is invoked with the given key and data
    /// </summary>
    public static UnityAction<string, object> onGlobalEventInvoked;

    /// <summary>
    /// Invoked when an enemy is killed
    /// </summary>
    public static UnityAction<EnemyData> onEnemyKilled;
}
