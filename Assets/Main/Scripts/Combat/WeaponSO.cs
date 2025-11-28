using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Weapon", menuName = "Combat/Weapon")]
public class WeaponSO : ScriptableObject
{
    public List<WeaponSequence> sequences;

    public UnityAction<WeaponAction> onWeaponActionChanged;

    public void Initialize(WeaponContext context)
    {
        for (int i = 0; i < sequences.Count; i++)
        {
            sequences[i] = Instantiate(sequences[i]);
        }

        foreach (var sequence in sequences)
        {
            sequence.Initialize(context);
            sequence.onWeaponActionChanged += SendWeaponActionChangedEvent;
        }
    }

    public void ResetWeapon()
    {
        foreach (var sequence in sequences)
        {
            sequence.ChangeAction(sequence.initialAction);
        }
    }
    public void OnUpdate()
    {
        foreach (var sequence in sequences)
        {
            sequence.Update();
        }
    }
    public void OnPhysicsUpdate()
    {
        foreach(var sequence in sequences)
        {
            sequence.PhysicsUpdate();
        }
    }

    private void SendWeaponActionChangedEvent(WeaponAction weaponAction)
    {
        onWeaponActionChanged?.Invoke(weaponAction);
    }
}
