using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
    public HitResult Hit(float damage);
}

public class HitResult { }
