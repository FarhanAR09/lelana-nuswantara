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
        SetActiveWeapon(Instantiate(activeWeapon));
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

    public void SetActiveWeapon(WeaponSO weaponInstance)
    {
        if (weaponInstance == null)
            return;

        if (activeWeapon != null && firstWeaponInitialized)
            activeWeapon.ResetWeapon();

        activeWeapon = weaponInstance;

        activeWeapon.Initialize(WeaponContext);
        activeWeapon.ResetWeapon();

        firstWeaponInitialized = true;
    }
}
