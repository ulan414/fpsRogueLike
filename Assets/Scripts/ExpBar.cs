using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI ExpText;
    [SerializeField] TMPro.TextMeshProUGUI LevelText;

    public float lerpSpeed = 0.1f;
    bool startLevel = true;

    public void UpdateExpSlider(int current, int target)
    {
        ExpText.text = current + "/" + target;
        slider.maxValue = target;
        if (current == 0 && !startLevel)
        {
            current = target;
        }
        startLevel = false;
        StartCoroutine(LerpExpSlider(current, target));

    }

    private IEnumerator LerpExpSlider(int current, int target)
    {
        float elapsedTime = 0f;
        float startValue = slider.value;

        while (elapsedTime < lerpSpeed)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / lerpSpeed);
            float lerpedValue = Mathf.Lerp(startValue, current, t);
            slider.value = lerpedValue;
            yield return null;
        }

        // Set the final value to ensure accuracy
        if (current == target)
        {
            slider.value = 0;
        }
        else
        {
            slider.value = current;
        }
    }

    public void UpdateLevelText(int level)
    {
        LevelText.text = "Level: " + level;
    }
}
