using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Combat/Weapon")]
public class WeaponSO : ScriptableObject
{
    public List<WeaponSequence> sequences;

    public void Initialize(WeaponContext context)
    {
        foreach (var sequence in sequences)
        {
            sequence.Initialize(context);
        }
    }

    public void ResetWeapon()
    {
        foreach (var sequence in sequences)
        {
            sequence.ChangeAction(sequence.actions[0]);
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
}
