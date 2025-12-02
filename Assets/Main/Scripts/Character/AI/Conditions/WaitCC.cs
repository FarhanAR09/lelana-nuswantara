using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wait Seconds with Context", menuName = "Character/Conditions/Wait Seconds with Context")]
public class WaitCC : CharacterStateTransitionCondition
{
    [Tooltip("Context key in CoroutineRunner context")]
    public string waitCoroutineKey;
    [Tooltip("Context key in GameObjectContextContainer context")]
    public string waitDurationKey;
    private bool waitDone = false;

    private GameObjectContextContainer contextContainer;

    public override bool IsMet(CharacterBrain brain)
    {
        return waitDone;
    }

    public override void OnEnter(CharacterBrain brain)
    {
        contextContainer = brain.gameObject.GetComponent<GameObjectContextContainer>();
        if (contextContainer != null)
        {
            brain.CoroutineRunner.StopSingleCoroutine(waitCoroutineKey);
            brain.CoroutineRunner.StartSingleCoroutine(waitDurationKey, Wait(contextContainer.Get<float>(waitDurationKey, 0f)));
        }
    }

    public override void OnExit(CharacterBrain brain)
    {
        waitDone = false;
    }

    private IEnumerator Wait(float duration)
    {
        waitDone = false;
        yield return new WaitForSeconds(duration);
        waitDone = true;
    }
}
