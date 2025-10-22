using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Combat/Weapon")]
public class WeaponSO : ScriptableObject
{
    public List<WeaponSequence> sequences;

    public void Initialize(WeaponContext context)
    {
        for (int i = 0; i < sequences.Count; i++)
        {
            sequences[i] = Instantiate(sequences[i]);
        }

        foreach (var sequence in sequences)
        {
            sequence.Initialize(context);
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
}
