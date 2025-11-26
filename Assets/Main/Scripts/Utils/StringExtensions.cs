using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtensions
{
    public static bool IsNotNullOrEmpty(this string str)
    {
        return str != null && str != "";
    }
}
