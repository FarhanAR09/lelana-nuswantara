using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CoroutineRunner))]
[DefaultExecutionOrder(-2147483648)]
public class CombatManager : MonoBehaviour
{
    public bool equipActiveWeaponOnStart = true;
    public WeaponSO activeWeapon;
    public WeaponContext WeaponContext { get; private set; } = new();
    public CoroutineRunner CoroutineRunner { get; private set; }

    private bool firstWeaponInitialized = false;

    public UnityAction<WeaponSO> onWeaponChanged;

    private void Awake()
    {
        WeaponContext.combatManager = this;
        CoroutineRunner = GetComponent<CoroutineRunner>();
    }

    private void Start()
    {
        if (equipActiveWeaponOnStart && activeWeapon != null)
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

    /// <summary>
    /// Instantiate Weapon before setting as active weapon
    /// </summary>
    /// <param name="weaponInstance"> INSTANCE of a WeaponSO </param>
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

        onWeaponChanged?.Invoke(activeWeapon);
    }
}
