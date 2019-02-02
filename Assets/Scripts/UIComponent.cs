using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIComponent : MonoBehaviour
{
    [SerializeField]
    private bool startHidden = true;

    [SerializeField]
    private float fadeDuration = 1.0f;

    private float fadeValue = 0;

    private CanvasGroup canvasGroup;

    public void Initialize()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if(startHidden){
            canvasGroup.alpha = 0;
        }
    }

    public IEnumerator FadeIn()
    {
        float lerp = 0;
        while(fadeValue < 1)
        {
            lerp += Time.deltaTime / fadeDuration;
            fadeValue = Mathf.Lerp(fadeValue, 1, lerp);
            canvasGroup.alpha =  fadeValue;
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        float lerp = 0;
        while(fadeValue > 0)
        {
            lerp += Time.deltaTime / fadeDuration;
            fadeValue = Mathf.Lerp(fadeValue, 0, lerp);
            canvasGroup.alpha =  fadeValue;
            yield return null;
        }
    }
}
