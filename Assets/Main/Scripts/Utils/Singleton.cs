using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null )
            {
                Debug.LogWarning("" + typeof(T).Name + " is null");
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
        else if (_instance != this)
        {
            print("" + typeof(T).Name + " already exists, destroying gameObject " + name);
            Destroy(gameObject);
        }
    }
}
