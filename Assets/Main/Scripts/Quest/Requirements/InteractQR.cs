using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractQR : QuestRequirementSO
{
    public string targetInteractibleId;
    public string interacteQuestContextKey;

    public override bool IsComplete()
    {
        return QuestSystem.Instance.GetContext<bool>(interacteQuestContextKey, false);
    }

    public override void Register()
    {
        GlobalEvent.onInteractibleInteracted += TrackIfInteracted;
    }

    public override void Unregister()
    {
        GlobalEvent.onInteractibleInteracted += TrackIfInteracted;
    }

    private void TrackIfInteracted(Interactible interactedCharacter)
    {
        if (interactedCharacter.InteractibleId != targetInteractibleId)
            return;
        QuestSystem.Instance.SetContext(interacteQuestContextKey, true);
        onCompleted?.Invoke();
    }
}
