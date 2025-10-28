using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockbackable
{
    public void Knockback(Vector2 velocity, float duration = 0.5f);
}
