using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionSO : ScriptableObject
{
    public abstract void Invoke(object args);
}
