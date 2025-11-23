using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Action/Set Active")]
public class SetActiveActionSO : ActionSO
{
    public string gameObjectName;
    public bool active;

    public override void Invoke(object args)
    {
        Debug.Log("Fuck you");
        GameObject gameObject = FindInSceneRecursive(gameObjectName);
        if (gameObject == null)
        {
            Debug.LogError("GameObject not found: " + gameObjectName);
            return;
        }
        gameObject.SetActive(active);
    }

    private GameObject FindInSceneRecursive(string name)
    {
        // Get active scene
        var scene = SceneManager.GetActiveScene();
        var roots = scene.GetRootGameObjects();

        // Search each root object recursively
        foreach (var root in roots)
        {
            var found = FindChildRecursive(root.transform, name);
            if (found != null)
                return found;
        }

        return null;
    }

    private GameObject FindChildRecursive(Transform parent, string name)
    {
        if (parent.name == name)
            return parent.gameObject;

        foreach (Transform child in parent)
        {
            var found = FindChildRecursive(child, name);
            if (found != null)
                return found;
        }

        return null;
    }
}
