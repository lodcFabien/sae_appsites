using System;
using UnityEngine;
using static Enums;

public class ScreenController : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.NewSreenEvent.AddListener(ActionOnNewScreen);
    }

    private void ActionOnNewScreen(ScreenController newScreen)
    {
        this.gameObject.SetActive(newScreen == this);   
    }
}
