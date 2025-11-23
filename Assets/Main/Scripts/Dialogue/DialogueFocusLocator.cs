using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-9999)]
public class DialogueFocusLocator : Singleton<DialogueFocusLocator>
{
    private List<DialogueFocusObject> focusObjects = new();

    public void Register(DialogueFocusObject focusObject)
    {
        focusObjects.Add(focusObject);
    }

    public void Unregister(DialogueFocusObject focusObject)
    {
        focusObjects.Remove(focusObject);
    }

    public Transform FindFocusObject(string id)
    {
        var obj = focusObjects.Find(x => x.Id == id);
        return obj != null ? obj.transform : null;
    }
}
