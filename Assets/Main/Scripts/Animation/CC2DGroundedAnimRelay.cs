using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC2DGroundedAnimRelay : MonoBehaviour
{
    public CharacterController2D character;
    public Animator animator;
    public string parameterName = "squash-down";
    public int parameterHash;

    bool lastGrounded = false;

    private void Awake()
    {
        parameterHash = Animator.StringToHash(parameterName);
    }

    private void Update()
    {
        bool grounded = character.isGrounded;

        if (!lastGrounded && grounded)
        {
            animator.SetTrigger(parameterHash);
        }

        lastGrounded = grounded;
    }
}
