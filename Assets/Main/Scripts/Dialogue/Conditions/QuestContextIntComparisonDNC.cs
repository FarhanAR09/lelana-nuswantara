using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Condition/Quest Context Int Comparison", fileName = "Quest Context Int Comparison")]
public class QuestContextIntComparisonDNC : DialogueNodeCondition
{
    public string contextKey;
    public int comparedValue;
    public Comparison comparison = Comparison.Equal;

    public override bool IsMet()
    {
        if (QuestSystem.Instance == null ||
            !QuestSystem.Instance.HasContext(contextKey) ||
            !QuestSystem.Instance.IsContextOfType<int>(contextKey))
            return false;

        int value = QuestSystem.Instance.GetContext<int>(contextKey, 0);

        return comparison switch
        {
            Comparison.Equal => comparedValue == value,
            Comparison.NotEqual => comparedValue != value,
            Comparison.GreaterThan => comparedValue > value,
            Comparison.GreaterThanOrEqual => comparedValue >= value,
            Comparison.LessThan => comparedValue < value,
            Comparison.LessThanOrEqual => comparedValue <= value,
            _ => false,
        };
    }

    public enum Comparison
    {
        Equal,
        NotEqual,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
    }
}
