using System;
using UnityEngine;
using static Enums;

public class NewScreenButtonController : MonoBehaviour
{
    [SerializeField] protected ScreenController _screenToActivate;

    public virtual void OnClick()
    {
        GameManager.Instance.SetNewScreen(_screenToActivate);
    }
}
