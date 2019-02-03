using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Window : UIComponent
{
    [SerializeField]
    private UnityEvent onOpen;

    [SerializeField]
    private UnityEvent onClose;

    [SerializeField]
    private Text headerTextComponent;

    [SerializeField]
    private Button headerCloseButtonComponent;

    [SerializeField]
    private string windowHeaderTitle = "[WINDOW TITLE]";

    private Coroutine windowStateCoroutine;

    void Start()
    {   
        base.Initialize();

        // sanity checks
        if(onOpen == null)
        {
            onOpen = new UnityEvent();
        }

        if(onClose == null)
        {
            onClose = new UnityEvent();
        }

        headerTextComponent.text = windowHeaderTitle;
        // adding listeners
        onOpen.AddListener(OnWindowOpen);
        onClose.AddListener(OnWindowClose);
        headerCloseButtonComponent.onClick.AddListener(OnCloseButton);
    }

    public void Open()
    {
        onOpen.Invoke();
        if(windowStateCoroutine != null)
            StopCoroutine(windowStateCoroutine);
        

        if(animationType == AnimationType.Fade){
            windowStateCoroutine = StartCoroutine(FadeIn());
        }
        else if(animationType == AnimationType.Movement){
            windowStateCoroutine = StartCoroutine(Move(moveIn:true));
        }
    }

    public void Close()
    {
        onClose.Invoke();
        if(windowStateCoroutine != null)
            StopCoroutine(windowStateCoroutine);
            
        if(animationType == AnimationType.Fade){
            windowStateCoroutine = StartCoroutine(FadeOut());
        }
        else if(animationType == AnimationType.Movement){
            windowStateCoroutine = StartCoroutine(Move(moveIn:false));
        }
    }

    void OnCloseButton()
    {
        Debug.Log("OnCloseButton executed");
    }

    void OnWindowOpen()
    {
        Debug.Log("OnWindowOpen executed");
    }

    void OnWindowClose()
    {
        Debug.Log("OnWindowClose executed");   
    }
}

