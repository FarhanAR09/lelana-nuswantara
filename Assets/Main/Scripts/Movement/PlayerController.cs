using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private MovementBrain brain;

    private void Update()
    {
        brain.inputs.horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            brain.inputs.downJump = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            brain.inputs.inJump = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            brain.inputs.upJump = true;
        }
    }
}
