using UnityEngine;

[CreateAssetMenu(menuName = "Movement/Conditions/Grounded Consecutive")]
public class GroundedConsecutiveMTC : MovementTransitionCondition
{
    public bool isGrounded = true;
    public float requiredDuration = 0.1f;

    private float timer = 0f;

    public override bool IsMet(MovementBrain brain)
    {
        if (timer <= requiredDuration)
        {
            timer += Time.deltaTime;
            return false;
        }

        timer = 0f;
        return brain.cc.isGrounded == isGrounded;
    }

    public override void OnEnter()
    {
        timer = 0f;
    }

    public override void OnExit()
    {
        timer = 0f;
    }
}
