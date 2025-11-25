using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TagUtils
{
    public static bool HasTag(string tag, List<Tag> tags)
    {
        return tags.Contains((Tag)System.Enum.Parse(typeof(Tag), tag));
    }
}

public enum Tag
{
    Default, Player, NPC, Enemy
}
