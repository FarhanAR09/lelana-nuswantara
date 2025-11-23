using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueFocusObject : MonoBehaviour
{
    [field: SerializeField]
    public string Id { get; private set; }

    private void Awake()
    {
        if (DialogueFocusLocator.Instance != null)
        {
            DialogueFocusLocator.Instance.Register(this);
        }
    }

    private void OnDestroy()
    {
        if (DialogueFocusLocator.Instance != null)
        {
            DialogueFocusLocator.Instance.Unregister(this);
        }
    }
}
