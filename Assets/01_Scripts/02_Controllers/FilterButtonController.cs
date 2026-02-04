using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using static Enums;

public class FilterButtonController : MonoBehaviour
{
    [SerializeField] private FilterType _filterType;
    [SerializeField] private FilterButtonView _view;

    private bool _activated = true;

    private void Awake()
    {
        GameManager.Instance.InitEvent.AddListener(Init);
    }

    private void Init()
    {
        SetActivated(true);
    }

    public void SwitchActivated()
    {
        SetActivated(!_activated);
    }

    public void SetActivated(bool activated)
    {
        _activated = activated;
        FilterManager.Instance.EditFilter(_filterType, _activated);
        _view.SetActivated(activated);
    }


}
