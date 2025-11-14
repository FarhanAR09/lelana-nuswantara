using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TQDRewardInvoker : MonoBehaviour
{
    public string rewardActionKey = "TQDQuestCompleted";

    private void OnEnable()
    {
        GlobalEvent.onGlobalEventInvoked += InvokeReward;
    }

    private void OnDisable()
    {
        GlobalEvent.onGlobalEventInvoked -= InvokeReward;
    }

    private void InvokeReward(string key, object args)
    {
        if (key == rewardActionKey)
        {
            print("===== TQD Quest Completed =====");
        }
    }
}
