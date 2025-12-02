using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour, IHittable
{
    [SerializeField]
    private Health health;
    [SerializeField]
    private MovementBrain brain;
    [SerializeField]
    private CombatManager combatManager;
    [SerializeField]
    private InteractibleDetector interactibleDetector;

    public WeaponSO weapon1Data, weapon2Data;
    private WeaponSO weapon1, weapon2;

    private bool inputEnabled = true;

    public UnityAction OnHit { get; set; }

    private void OnEnable()
    {
        DialogueView.Instance.OnDialogueStart.AddListener(DisableInput);
        DialogueView.Instance.OnDialogueEnd.AddListener(EnableInput);

        health.onDie += DisableInput;
    }

    private void OnDisable()
    {
        DialogueView.Instance.OnDialogueStart.RemoveListener(DisableInput);
        DialogueView.Instance.OnDialogueEnd.RemoveListener(EnableInput);

        health.onDie -= DisableInput;
    }

    private void Awake()
    {
        weapon1 = Instantiate(weapon1Data);
        weapon2 = Instantiate(weapon2Data);

        combatManager.SetActiveWeapon(
                combatManager.activeWeapon == weapon1 ? weapon2 : weapon1);
    }

    private void Update()
    {
        if (inputEnabled)
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
                combatManager.SetActiveWeapon(
                    combatManager.activeWeapon == weapon1 ? weapon2 : weapon1);
            }
        }
    }

    private void EnableInput()
    {
        inputEnabled = true;
    }

    private void DisableInput()
    {
        inputEnabled = false;
    }

    public HitResult Hit(float damage)
    {
        health.TakeDamage(damage);
        OnHit?.Invoke();
        return new HitResult();
    }

    private void StartDeathSequence()
    {
        
    }
}
