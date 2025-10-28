using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement/Conditions/Wait with Context Key", fileName = "Wait with Context Key")]
public class WaitMTC : MovementTransitionCondition
{
    public string waitDurationContextKey;
    private Coroutine waitCoroutine;
    private bool waitDone = false;

    public override bool IsMet(MovementBrain brain)
    {
        return waitDone;
    }

    public override void OnEnter()
    {
        waitDone = false;
        IEnumerator Wait()
        {
            float duration = 0f;
            if (owner.TryGetComponent(out GameObjectContextContainer cc))
            {
                duration = (float)cc.context[waitDurationContextKey];
            }
            yield return new WaitForSeconds(duration);
            waitDone = true;
        }
        if (waitCoroutine != null)
            owner.StopCoroutine(waitCoroutine);
        waitCoroutine = owner.StartCoroutine(Wait());
    }

    public override void OnExit()
    {
        if (waitCoroutine != null)
            owner.StopCoroutine(waitCoroutine);
        waitDone = false;
    }
}
