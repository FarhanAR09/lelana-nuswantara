using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GameObjectContextContainer))]
public class KnockbackableExtension : MonoBehaviour, IKnockbackable
{
    public string durationContextKey = "KnockbackDuration";
    public string velocityContextKey = "KnockbackVelocity";
    public UnityAction onKnockbacked;

    private GameObjectContextContainer contextContainer;

    private void Awake()
    {
        contextContainer = GetComponent<GameObjectContextContainer>();
    }

    public void Knockback(Vector2 velocity, float duration = 0.5f)
    {
        contextContainer.context[durationContextKey] = duration;
        contextContainer.context[velocityContextKey] = velocity;
        onKnockbacked?.Invoke();
    }
}
