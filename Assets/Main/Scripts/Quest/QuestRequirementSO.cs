using UnityEngine;
using UnityEngine.Events;

public abstract class QuestRequirementSO : ScriptableObject
{
    public abstract bool IsComplete();
    public abstract void Register();
    public abstract void Unregister();
    public UnityAction onCompleted;
}
