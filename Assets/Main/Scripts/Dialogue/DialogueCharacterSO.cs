using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Character", fileName = "New Character")]
public class DialogueCharacterSO : ScriptableObject
{
    public string characterName;
    public Sprite defaultPortrait;
    public List<EmotionPortrait> emotionsPortrait;

    public Sprite GetPortrait(DialogueEmotion emotion)
    {
        if (emotionsPortrait != null && emotionsPortrait.Count > 0)
        {
            foreach (EmotionPortrait ep in emotionsPortrait)
            {
                if (ep.emotion == emotion)
                {
                    return ep.portrait;
                }
            }
        }
        return defaultPortrait;
    }
}

[Serializable]
public class EmotionPortrait
{
    public DialogueEmotion emotion;
    public Sprite portrait;
}

public enum DialogueEmotion
{
    Neutral,
    Happy,
    Sad,
    Angry
}
