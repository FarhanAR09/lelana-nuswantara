using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputs
{
    public float horizontal = 0f;
    public float vertical = 0f;
    public bool downJump = false, inJump = false, upJump = false;

    public void ResetInputs()
    {
        horizontal = 0f;
        vertical = 0f;
        downJump = false; inJump = false; upJump = false;
    }
}
