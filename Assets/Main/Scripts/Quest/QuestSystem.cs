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
    
    #region Quests
    public List<QuestSO> ActiveQuests { get; private set; } = new();
    public List<QuestSO> ReadyToTurnInQuests { get; private set; } = new();
    public List<QuestSO> CompletedQuests { get; private set; } = new();
    public List<QuestSO> AllQuests
    {
        get
        {
            List<QuestSO> allQuests = new();
            allQuests.AddRange(ActiveQuests);
            allQuests.AddRange(ReadyToTurnInQuests);
            allQuests.AddRange(CompletedQuests);
            return allQuests;
        }
    }

    public void AddToActiveQuest(QuestSO quest)
    {
        if (AllQuests.Contains(quest))
            return;

        quest.RegisterRequirements();
        quest.onCompleted += FulfillActiveQuest;
        ActiveQuests.Add(quest);
    }

    public void RemoveFromActiveQuest(QuestSO quest)
    {
        if (!ActiveQuests.Contains(quest))
            return;

        quest.UnregisterRequirements();
        quest.onCompleted -= FulfillActiveQuest;
        ActiveQuests.Remove(quest);
    }

    private void FulfillActiveQuest(QuestSO quest)
    {
        Debug.Log("Fulfilled Quest: " + quest.name);
        if (!ActiveQuests.Contains(quest))
            return;

        RemoveFromActiveQuest(quest);
        ReadyToTurnInQuests.Add(quest);
        if (quest.autoTurnIn)
        {
            TurnInQuest(quest);
        }
    }

    public void TurnInQuest(QuestSO quest)
    {
        if (ActiveQuests.Contains(quest) || ReadyToTurnInQuests.Contains(quest))
        {
            ReadyToTurnInQuests.Remove(quest);
            CompletedQuests.Add(quest);
            quest.GiveReward();
        }
    }
    #endregion
}
