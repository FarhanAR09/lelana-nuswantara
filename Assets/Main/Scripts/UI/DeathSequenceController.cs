using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathSequenceController : MonoBehaviour
{
    public Health playerHealth;

    public Image panel;
    public Image rahwanaImage;
    public TextMeshProUGUI gameOverText, continueText;

    public float timer = 0f, duration = 1f;

    private void OnEnable()
    {
        playerHealth.onDie += StartSequence;
    }

    private void OnDisable()
    {
        playerHealth.onDie -= StartSequence;
    }

    private Coroutine sequence;
    [ContextMenu("Start Sequence")]
    private void StartSequence()
    {
        IEnumerator Animation()
        {
            panel.gameObject.SetActive(true);
            timer = 0f;
            while (timer < duration)
            {
                timer += Time.deltaTime;
                panel.color = Color.Lerp(Color.clear, Color.black, timer / duration);
                yield return null;
            }
            timer = 0f;
            while (timer < duration)
            {
                timer += Time.deltaTime;
                rahwanaImage.color = Color.Lerp(new Color(1f, 1f, 1f, 0f), Color.white, timer / duration);
                yield return null;
            }
            timer = 0f;
            while (timer < duration)
            {
                timer += Time.deltaTime;
                gameOverText.color = Color.Lerp(new Color(1f, 0f, 0f, 0f), Color.red, timer / duration);
                yield return null;
            }
            timer = 0f;
            while (timer < duration)
            {
                timer += Time.deltaTime;
                continueText.color = Color.Lerp(new Color(1f, 0f, 0f, 0f), Color.red, timer / duration);
                yield return null;
            }
        }
        if (sequence != null) {
            StopCoroutine(sequence);
        }
        sequence = StartCoroutine(Animation());
    }
}
