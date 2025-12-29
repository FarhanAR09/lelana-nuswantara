using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityProviderAnimationRelay : MonoBehaviour
{
    [Tooltip("Must be IVelocityProvider")]
    public MonoBehaviour velocityProviderMono;
    private IVelocityProvider VelocityProvider { get { return velocityProviderMono as IVelocityProvider; } }
    public float minSpeed = 0f, maxSpeed = 1f;

    [Header("Animator")]
    public Animator animator;
    public string animationParameter = "stopToFast";
    private int animHash;
    public AnimatorControllerParameterType parameterType = AnimatorControllerParameterType.Float;

    [Header("Bool Parameter")]
    public bool isFlipped = false;
    private float lastNonZeroX = 0f;


    private Vector3 prevVelocity = Vector3.zero;

    private void Awake()
    {
        animHash = Animator.StringToHash(animationParameter);
    }

    private void Update()
    {
        if (prevVelocity != VelocityProvider.Velocity)
        {
            float horizontalVelocity = VelocityProvider.Velocity.x;
            switch (parameterType)
            {
                case AnimatorControllerParameterType.Float:
                    animator.SetFloat(animHash, Mathf.Abs(horizontalVelocity).Normalize(minSpeed, maxSpeed));
                    break;
                case AnimatorControllerParameterType.Bool:
                    const float deadZone = 0.01f;

                    if (Mathf.Abs(horizontalVelocity) > deadZone)
                    {
                        lastNonZeroX = horizontalVelocity;
                    }

                    bool facingRight = !isFlipped
                        ? lastNonZeroX > 0
                        : lastNonZeroX < 0;

                    animator.SetBool(animHash, facingRight);
                    break;
            }
            

            prevVelocity = VelocityProvider.Velocity;
        }
    }
}
