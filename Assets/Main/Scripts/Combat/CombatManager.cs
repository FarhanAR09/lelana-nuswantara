using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-2147483648)]
public class CombatManager : MonoBehaviour
{
    public WeaponSO activeWeapon;
    public WeaponContext WeaponContext { get; private set; } = new();

    private bool firstWeaponInitialized = false;

    private void Start()
    {
        SetActiveWeapon(activeWeapon);
    }

    private void Update()
    {
        if (activeWeapon != null)
            activeWeapon.OnUpdate();

        WeaponContext.ResetInputs();
    }

    private void FixedUpdate()
    {
        if (activeWeapon != null)
            activeWeapon.OnPhysicsUpdate();
    }

    public void SetActiveWeapon(WeaponSO weapon)
    {
        if (weapon == null)
            return;

        if (activeWeapon != null && firstWeaponInitialized)
            activeWeapon.ResetWeapon();

        activeWeapon = weapon;

        activeWeapon.Initialize(WeaponContext);
        activeWeapon.ResetWeapon();

        firstWeaponInitialized = true;
    }
}
