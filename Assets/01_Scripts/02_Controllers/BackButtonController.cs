using System;
using UnityEngine;

public class BackButtonController : NewScreenButtonController
{
    private void Awake()
    {
        GameManager.Instance.NewSreenEvent.AddListener(ActionOnNewScreen);
    }

    private void ActionOnNewScreen(ScreenController newScreen)
    {
        this.gameObject.SetActive(newScreen != _screenToActivate);
    }

    public override void OnClick()
    {
        base.OnClick();
        PopupManager.Instance.HidePopup();
    }
}
