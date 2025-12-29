using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSAnimationRelay : MonoBehaviour
{
    public Animator animator;
    public MovementState movementState;
    public TriggerType triggerType = TriggerType.All;
    public AnimatorControllerParameterType parameterType = AnimatorControllerParameterType.Bool;

    public string parameterName;
    public bool setBoolTo = true;

    private void OnEnable()
    {
        movementState.onEnter += OnMSEnter;
        movementState.onExit += OnMSExit;
    }

    private void OnDisable()
    {
        movementState.onEnter -= OnMSEnter;
        movementState.onExit -= OnMSExit;
    }

    private void OnMSEnter()
    {
        if (triggerType == TriggerType.Enter || triggerType == TriggerType.All)
        {
            switch (parameterType)
            {
                case AnimatorControllerParameterType.Trigger:
                    animator.SetTrigger(parameterName);
                    break;
                case AnimatorControllerParameterType.Bool:
                    animator.SetBool(parameterName, setBoolTo);
                    break;
            }
        }
    }

    private void OnMSExit()
    {
        if (triggerType == TriggerType.Exit || triggerType == TriggerType.All)
        {
            switch (parameterType)
            {
                case AnimatorControllerParameterType.Trigger:
                    animator.SetTrigger(parameterName);
                    break;
                case AnimatorControllerParameterType.Bool:
                    animator.SetBool(parameterName, setBoolTo);
                    break;
            }
        }
    }

    public enum AnimatorPropertyType
    {
        Bool,
        Float,
        Trigger
    }

    public enum TriggerType
    {
        All,
        Enter,
        Exit
    }
}
