using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIComponent : MonoBehaviour
{

#region General Variables

    [SerializeField]
    private bool startHidden = true;

    private CanvasGroup canvasGroup;
  
    private RectTransform rectTransform;

    public bool StartHidden 
    {
        get => startHidden;
        set => startHidden = value;
    }    

    private Vector3 anchoredPosition3D = Vector3.zero;

#endregion
    
#region Animation Types

    public enum AnimationType
    {
        None,
        Fade,
        Movement
    }

    [SerializeField]
    private AnimationType animationTypeIn = AnimationType.None;

    public AnimationType AnimationIn 
    {
        get => animationTypeIn;
        set => animationTypeIn = value;
    }

    [SerializeField]
    private AnimationType animationTypeOut = AnimationType.None;

    public AnimationType AnimationOut 
    {
        get => animationTypeOut;
        set => animationTypeOut = value;
    }

#endregion

#region Fade Animations 

    private float fadeValue = 0;

    [SerializeField]
    private float fadeInDuration = 1.0f;

    public float FadeInDuration 
    {
        get => fadeInDuration;
        set => fadeInDuration = value;
    }

    [SerializeField]
    private float fadeOutDuration = 1.0f;

    public float FadeOutDuration 
    {
        get => fadeOutDuration;
        set => fadeOutDuration = value;
    }

#endregion

#region Move Animations

    [SerializeField]
    private float moveInDuration = 0;

    public float MoveInDuration 
    {
        get => moveInDuration;
        set => moveInDuration = value;
    }

    [SerializeField]
    private Vector3 moveInFrom = Vector3.zero;

    public Vector3 MoveInFrom
    {
        get => moveInFrom;
        set => moveInFrom = value;
    }

    [SerializeField]
    private Vector3 moveInTo = Vector3.zero;

    public Vector3 MoveInTo
    {
        get => moveInTo;
        set => moveInTo = value;
    }

    [SerializeField]
    private float moveOutDuration = 0;

    public float MoveOutDuration 
    {
        get => moveOutDuration;
        set => moveOutDuration = value;
    }

    [SerializeField]
    private Vector3 moveOutFrom = Vector3.zero;

    public Vector3 MoveOutFrom
    {
        get => moveOutFrom;
        set => moveOutFrom = value;
    }

    [SerializeField]
    private Vector3 moveOutTo = Vector3.zero;

    public Vector3 MoveOutTo
    {
        get => moveOutTo;
        set => moveOutTo = value;
    }
    private Vector3 moveValue = Vector3.zero;

#endregion    

    public void Initialize()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        anchoredPosition3D = rectTransform.anchoredPosition3D;

        if(startHidden){
            canvasGroup.alpha = 0;
        }
    }

    public IEnumerator MoveIn()
    {
        float lerp = 0;
        canvasGroup.alpha = 1;

        while(true)
        {
            lerp += Time.deltaTime / moveInDuration;
            moveValue = Vector3.Lerp(moveInFrom, moveInTo, lerp);
            rectTransform.anchoredPosition3D = moveValue;

            if(Vector3.Distance(moveInTo, rectTransform.anchoredPosition3D) < 1.0){
                break;
            }

            yield return null;
        }
    }

    public IEnumerator MoveOut()
    {
        float lerp = 0;
        canvasGroup.alpha = 1;

        while(true)
        {
            lerp += Time.deltaTime / moveOutDuration;
            moveValue = Vector3.Lerp(moveOutFrom, moveOutTo, lerp);
            rectTransform.anchoredPosition3D = moveValue;

            if(Vector3.Distance(moveOutTo, rectTransform.anchoredPosition3D) < 1.0){
                Reset();
                break;
            }
            yield return null;
        }
    }

    private void Reset() 
    {
        rectTransform.anchoredPosition3D = anchoredPosition3D;
        canvasGroup.alpha = 0;
        fadeValue = 0;
        moveValue = Vector3.zero;
    }

    public IEnumerator FadeIn()
    {
        float lerp = 0;
        fadeValue = 0;
        while(fadeValue < 1)
        {
            lerp += Time.deltaTime / fadeInDuration;
            fadeValue = Mathf.Lerp(fadeValue, 1, lerp);
            canvasGroup.alpha =  fadeValue;
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        float lerp = 0;
        fadeValue = 1;
        while(fadeValue > 0)
        {
            lerp += Time.deltaTime / fadeOutDuration;
            fadeValue = Mathf.Lerp(fadeValue, 0, lerp);
            canvasGroup.alpha =  fadeValue;
            yield return null;
        }
    }
}
