using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEventAnimRelay : MonoBehaviour
{
    public CombatManager combatManager;
    public Animator animator;
    public string weaponActionId = "";
    public string parameterName = "attack";
    private int parameterHash;

    private WeaponSO currentWeapon;

    private void OnEnable()
    {
        combatManager.onWeaponChanged += ResubscribeNewWeapon;

        if (combatManager.activeWeapon != null)
            ResubscribeNewWeapon(combatManager.activeWeapon);
    }

    private void OnDisable()
    {
        combatManager.onWeaponChanged -= ResubscribeNewWeapon;

        if (currentWeapon != null)
        {
            currentWeapon.onWeaponActionEventInvoked -= SetParameter;
        }
    }

    private void Awake()
    {
        parameterHash = Animator.StringToHash(parameterName);
    }

    private void Start()
    {
        if (combatManager.activeWeapon != null)
            ResubscribeNewWeapon(combatManager.activeWeapon);
    }

    private void ResubscribeNewWeapon(WeaponSO weapon)
    {
        if (currentWeapon != null)
        {
            currentWeapon.onWeaponActionEventInvoked -= SetParameter;
        }

        currentWeapon = weapon;

        if (currentWeapon != null) {
            currentWeapon.onWeaponActionEventInvoked += SetParameter;
        }
    }

    private void SetParameter(WeaponAction action, object arg)
    {
        if (action.id == weaponActionId)
        {
            animator.SetTrigger(parameterHash);
        }
    }
}
