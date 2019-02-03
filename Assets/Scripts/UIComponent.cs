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

    [SerializeField]
    protected AnimationType animationType = AnimationType.None;

    [SerializeField]
    private float moveDuration = 1.0f;

    [SerializeField]
    private Vector3 moveFrom, moveTo = Vector3.zero;

    private Vector3 moveValue = Vector3.zero;

    private RectTransform rectTransform = null;

    public enum AnimationType 
    {
        None,
        Fade,
        Movement
    }

    public void Initialize()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();

        if(startHidden){
            canvasGroup.alpha = 0;
        }
    }

    public IEnumerator Move(bool moveIn)
    {
        float lerp = 0;
        canvasGroup.alpha = 1;
        
        while(true)
        {
            lerp += Time.deltaTime / moveDuration;
            moveValue = moveIn ? Vector3.Lerp(moveFrom, moveTo, lerp) : Vector3.Lerp(moveTo, moveFrom, lerp);
            rectTransform.anchoredPosition3D = moveValue;

            if(Vector3.Distance(moveTo, rectTransform.anchoredPosition3D) < 1.0f)
                break;

            yield return null;
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
