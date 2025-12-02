using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IHittable
{
    public HitResult Hit(float damage);
    public UnityAction OnHit { get; set; }
}

public class HitResult { }
