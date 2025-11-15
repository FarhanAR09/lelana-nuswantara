using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Quest/Quest")]
public class QuestSO : ScriptableObject
{
    public string questName;
    public List<QuestRequirementSO> requirements;
    public bool autoTurnIn = true;

    public List<DialogueNodeSO> initialDialogue;
    public List<DialogueNodeSO> turnInDialogue;

    public UnityAction<QuestSO> onCompleted;
    public ActionSO rewardAction;

    public void RegisterRequirements()
    {
        foreach (var requirement in requirements)
        {
            requirement.Register();
            requirement.onCompleted += CheckCompleteQuest;
        }
    }

    public void UnregisterRequirements()
    {
        foreach (var requirement in requirements)
        {
            requirement.Unregister();
            requirement.onCompleted -= CheckCompleteQuest;
        }
    }

    private void CheckCompleteQuest()
    {
        foreach (var requirement in requirements)
        {
            if (!requirement.IsComplete())
                return;
        }
        Debug.Log(name + " is complete!");
        onCompleted?.Invoke(this);
    }

    public void GiveReward()
    {
        Debug.Log("Reward Given");
        rewardAction.Invoke(null);
    }
}