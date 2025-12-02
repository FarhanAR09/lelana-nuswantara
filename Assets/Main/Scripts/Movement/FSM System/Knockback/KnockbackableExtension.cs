using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GameObjectContextContainer))]
public class KnockbackableExtension : MonoBehaviour, IKnockbackable
{
    [Tooltip("GameObjectContextContainer key")]
    public string durationContextKey = "KnockbackDuration";
    [Tooltip("GameObjectContextContainer key")]
    public string velocityContextKey = "KnockbackVelocity";
    public UnityAction onKnockbacked;
    public bool IsKnockbacked { get; private set; } = false;

    private GameObjectContextContainer contextContainer;

    private Coroutine knockbackCoroutine;

    private void Awake()
    {
        contextContainer = GetComponent<GameObjectContextContainer>();
    }

    public void Knockback(Vector2 velocity, float duration = 0.5f)
    {
        contextContainer.context[durationContextKey] = duration;
        contextContainer.context[velocityContextKey] = velocity;

        if (knockbackCoroutine != null)
            StopCoroutine(knockbackCoroutine);
        knockbackCoroutine = StartCoroutine(KnockbackWait());

        onKnockbacked?.Invoke();
    }

    IEnumerator KnockbackWait()
    {
        IsKnockbacked = true;
        yield return new WaitForSeconds((float)contextContainer.context[durationContextKey]);
        IsKnockbacked = false;
    }
}
