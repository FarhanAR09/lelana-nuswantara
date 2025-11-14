using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : Singleton<QuestSystem>
{
    #region Context
    public Dictionary<string, object> Context { get; set; } = new();

    public void SetContext<T>(string key, T value)
    {
        Context[key] = value;
    }

    public T GetContext<T>(string key, T defaultValue = default)
    {
        if (Context.TryGetValue(key, out var value) && value is T tValue)
            return tValue;
        return defaultValue;
    }

    public bool HasContext(string key)
        => Context.ContainsKey(key);

    public bool IsContextOfType<T>(string key)
        => Context.ContainsKey(key) && Context[key] is T;
    #endregion
    
    #region Active Quests
    public List<QuestSO> ActiveQuests { get; private set; } = new();

    public void AddActiveQuest(QuestSO quest)
    {
        quest.RegisterRequirements();
        ActiveQuests.Add(quest);
    }

    public void RemoveActiveQuest(QuestSO quest)
    {
        quest.UnregisterRequirements();
        ActiveQuests.Remove(quest);
    }
    #endregion
}
