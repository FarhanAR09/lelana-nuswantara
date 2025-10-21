using UnityEngine;

[CreateAssetMenu(menuName = "Movement/Conditions/JumpPressed")]
public class JumpPressedMTC : MovementTransitionCondition
{
    public InputType inputType = InputType.Pressed;

    public override bool IsMet(MovementBrain brain)
    {
        return inputType switch
        {
            InputType.Pressed => brain.inputs.downJump,
            InputType.Held => brain.inputs.inJump,
            InputType.Released => brain.inputs.upJump,
            _ => false,
        };
    }

    public override void OnEnter()
    {
        
    }

    public override void OnExit()
    {
        
    }
}

public enum InputType
{
    Pressed,
    Held,
    Released
}
