using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Enums;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private TransitionController _transitionController;
    [SerializeField] private ScreenController _defaultScreen;
    
    
    private ScreenController _currentScreen;

    private UnityEvent _initEvent = new UnityEvent();    
    public UnityEvent InitEvent => _initEvent;    

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        _currentScreen = _defaultScreen;
        OnTransitionMiddle();
        _initEvent.Invoke();
    }

    private UnityEvent<ScreenController> _newSreenEvent = new UnityEvent<ScreenController>();
    public UnityEvent<ScreenController> NewSreenEvent => _newSreenEvent;    

    public void SetNewScreen(ScreenController newScreen)
    {
        _currentScreen = newScreen;
        _transitionController.StartTransition();
    }

    public void OnTransitionMiddle()
    {
        _newSreenEvent.Invoke(_currentScreen);
    }
}
