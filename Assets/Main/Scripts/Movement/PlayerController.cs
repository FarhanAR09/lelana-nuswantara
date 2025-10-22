using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private MovementBrain brain;
    [SerializeField]
    private CombatManager combatManager;

    public WeaponSO weapon1, weapon2;

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

        if (Input.GetMouseButtonDown(0))
        {
            combatManager.WeaponContext.fireDown = true;
        }
        if (Input.GetMouseButton(0))
        {
            combatManager.WeaponContext.fireIn = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            combatManager.WeaponContext.fireUp = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            combatManager.SetActiveWeapon(combatManager.activeWeapon != weapon1 ? weapon1 : weapon2);
        }
    }
}
