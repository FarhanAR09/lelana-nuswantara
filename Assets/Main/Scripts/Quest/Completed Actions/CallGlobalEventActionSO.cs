using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CallGlobalEventAction", menuName = "Quest/Completed Action/Call Global Event Action")]
public class CallGlobalEventActionSO : ActionSO
{
    public string eventKey;

    public override void Invoke(object args)
    {
        GlobalEvent.onGlobalEventInvoked?.Invoke(eventKey, args);
    }
}
