using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.LowLevel;

public static class CustomPlayerLoop
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        var loop = PlayerLoop.GetCurrentPlayerLoop();

        // Insert into EarlyUpdate phase
        InsertEarlyUpdate(ref loop);

        PlayerLoop.SetPlayerLoop(loop);
    }

    static void InsertEarlyUpdate(ref PlayerLoopSystem loop)
    {
        for (int i = 0; i < loop.subSystemList.Length; i++)
        {
            if (loop.subSystemList[i].type == typeof(UnityEngine.PlayerLoop.EarlyUpdate))
            {
                var subsystemList = loop.subSystemList[i].subSystemList;

                var customSystem = new PlayerLoopSystem
                {
                    type = typeof(CustomEarlyUpdateRunner),
                    updateDelegate = CustomEarlyUpdateRunner.Run
                };

                // insert at the start of EarlyUpdate block
                ArrayUtility.Insert(ref subsystemList, 0, customSystem);

                loop.subSystemList[i].subSystemList = subsystemList;
                return;
            }
        }
    }
}

public static class CustomEarlyUpdateRunner
{
    public static event Action OnEarlyUpdate;

    public static void Run()
    {
        OnEarlyUpdate?.Invoke();
    }
}
