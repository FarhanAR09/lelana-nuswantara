using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerUtils
{
    public static bool IsInLayerMask(int layer, LayerMask layerMask)
    {
        return layerMask == (layerMask | (1 << layer));
    }
}
