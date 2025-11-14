using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private MovementBrain brain;
    [SerializeField]
    private CombatManager combatManager;
    [SerializeField]
    private InteractibleDetector interactibleDetector;

    public WeaponSO weapon1Data, weapon2Data;
    private WeaponSO weapon1, weapon2;

    private void Awake()
    {
        weapon1 = Instantiate(weapon1Data);
        weapon2 = Instantiate(weapon2Data);

        combatManager.SetActiveWeaponInstance(
                combatManager.activeWeapon == weapon1 ? weapon2 : weapon1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactibleDetector.TryInteract();
        }

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
        if (Input.GetMouseButtonDown(1))
        {
            combatManager.WeaponContext.fireAltDown = true;
        }
        if (Input.GetMouseButton(1))
        {
            combatManager.WeaponContext.fireAltIn = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            combatManager.WeaponContext.fireAltUp = true;
        }

        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = -Camera.main.transform.position.z;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        combatManager.WeaponContext.aimDirection = (worldPos - transform.position).normalized;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            combatManager.SetActiveWeaponInstance(
                combatManager.activeWeapon == weapon1 ? weapon2 : weapon1);
        }
    }
}
