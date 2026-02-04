using System;
using UnityEngine;
using static Enums;

public class NewScreenButtonController : MonoBehaviour
{
    [SerializeField] protected ScreenController _screenToActivate;

    public void OnClick()
    {
        GameManager.Instance.SetNewScreen(_screenToActivate);
    }
}
