using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIComponent : MonoBehaviour
{
    [SerializeField]
    private bool startHidden = true;

    public bool StartHidden 
    {
        get => startHidden;
        set => startHidden = value;
    }    

    [SerializeField]
    private AnimationType animationType = AnimationType.None;

    public AnimationType Animation 
    {
        get => animationType;
        set => animationType = value;
    }

    [SerializeField]
    private float fadeDuration = 1.0f;

    public float FadeDuration 
    {
        get => fadeDuration;
        set => fadeDuration = value;
    }

    [SerializeField]
    private float moveDuration = 0;

    public float MoveDuration 
    {
        get => moveDuration;
        set => moveDuration = value;
    }

    [SerializeField]
    private Vector3 moveFrom = Vector3.zero;

    public Vector3 MoveFrom
    {
        get => moveFrom;
        set => moveFrom = value;
    }

    [SerializeField]
    private Vector3 moveTo = Vector3.zero;

    public Vector3 MoveTo
    {
        get => moveTo;
        set => moveTo = value;
    }

    private float fadeValue = 0;

    private CanvasGroup canvasGroup;

    public enum AnimationType
    {
        None,
        Fade,
        Movement
    }

    
    private Vector3 moveValue = Vector3.zero;

    private RectTransform rectTransform;

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

            if(Vector3.Distance(moveTo, rectTransform.anchoredPosition3D) < 1.0){
                break;
            }

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
