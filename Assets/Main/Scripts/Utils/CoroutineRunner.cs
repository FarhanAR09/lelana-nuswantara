using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour
{
    public Dictionary<string, Coroutine> RunningCoroutines { get; private set; } = new();

    public Coroutine StartSingleCoroutine(string key, IEnumerator routine)
    {
        if (RunningCoroutines.ContainsKey(key) && RunningCoroutines[key] != null)
        {
            StopCoroutine(RunningCoroutines[key]);
        }
        Coroutine coroutine = StartCoroutine(routine);
        RunningCoroutines[key] = coroutine;
        return coroutine;
    }
}
