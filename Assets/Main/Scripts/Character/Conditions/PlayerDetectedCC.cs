using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Detected", menuName = "Character/Conditions")]
public class PlayerDetectedCC : CharacterStateTransitionCondition
{
    private PlayerProximityDetector detector;

    [field: SerializeField]
    public string ContextKey { get; private set; } = "DetectedPlayerProximity";
    [field: SerializeField]
    public DetectionType Type { get; private set; } = DetectionType.PlayerBecomesDetected;

    public override bool IsMet(CharacterBrain brain)
    {
        if (detector == null)
        {
            Debug.LogError("PlayerDetectedCC requires a PlayerProximityDetector component");
            return false;
        }
        if (Type == DetectionType.PlayerBecomesDetected)
        {
            if (detector.PlayerDetected)
            {
                brain.Context[ContextKey] = detector.DetectedPlayer;
            }
            return detector.PlayerDetected;
        }
        else if (Type == DetectionType.PlayerBecomesNotDetected)
        {
            if (!detector.PlayerDetected)
            {
                brain.Context[ContextKey] = null;
            }
            return !detector.PlayerDetected;
        }
        return false;
    }

    public override void OnEnter()
    {
        detector = owner.GetComponent<PlayerProximityDetector>();
        if (detector == null)
        {
            Debug.LogError("PlayerDetectedCC requires a PlayerProximityDetector component");
        }
    }

    public override void OnExit()
    {
        
    }

    public enum DetectionType
    {
        PlayerBecomesDetected,
        PlayerBecomesNotDetected
    }
}
