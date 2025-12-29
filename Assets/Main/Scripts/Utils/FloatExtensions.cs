using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExtensions
{
    public static float Normalize(this float value, float min, float max)
        => (Mathf.Clamp(value, min, max) - min) / (max - min);
}
