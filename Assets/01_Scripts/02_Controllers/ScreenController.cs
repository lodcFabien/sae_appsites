using System;
using UnityEngine;
using static Enums;

public class ScreenController : MonoBehaviour
{
    protected virtual void Awake()
    {
        GameManager.Instance.NewSreenEvent.AddListener(ActionOnNewScreen);
    }

    protected virtual void ActionOnNewScreen(ScreenController newScreen)
    {
        this.gameObject.SetActive(newScreen == this);   
    }
}
