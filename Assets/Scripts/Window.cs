using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Window : UIComponent
{
    [SerializeField]
    private UnityEvent onOpen;

    public UnityEvent OnOpen
    {
        get => onOpen;
        set => onOpen = value;
    }

    [SerializeField]
    private UnityEvent onClose;

    public UnityEvent OnClose
    {
        get => onClose;
        set => onClose = value;
    }

    [SerializeField]
    private Text headerTextGameObject;

    public Text HeaderTextGameObject
    {
        get => headerTextGameObject;
        set => headerTextGameObject = value;
    }

    [SerializeField]
    private Button headerCloseButtonComponent;

    [SerializeField]
    private string windowHeaderTitle = "[WINDOW TITLE]";

    public string WindowHeaderTitle 
    {
        get => windowHeaderTitle;
        set => windowHeaderTitle = value;
    }

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

        headerTextGameObject.text = windowHeaderTitle;
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
        

        if(Animation == AnimationType.Fade){
            windowStateCoroutine = StartCoroutine(FadeIn());
        }
        else if(Animation == AnimationType.Movement){
            windowStateCoroutine = StartCoroutine(Move(moveIn:true));
        }
    }

    public void Close()
    {
        onClose.Invoke();
        if(windowStateCoroutine != null)
            StopCoroutine(windowStateCoroutine);
            
        if(Animation == AnimationType.Fade){
            windowStateCoroutine = StartCoroutine(FadeOut());
        }
        else if(Animation == AnimationType.Movement){
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

    public void TestingOnCloseUnityEvent()
    {
        Debug.Log("TestingOnCloseUnityEvent executed");
    }
}

