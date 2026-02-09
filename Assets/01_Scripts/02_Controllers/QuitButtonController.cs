using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class QuitButtonStatus
{
    public ScreenController ScreenController;
    public Sprite Image;
}

public class QuitButtonController : MonoBehaviour
{
    [SerializeField] private List<QuitButtonStatus> _status = new List<QuitButtonStatus>();
    [SerializeField] private Image _safranLogo;

    private int _count = 0;

    private void Awake()
    {
        GameManager.Instance.NewSreenEvent.AddListener(ActionOnNewScreen);
    }

    private void ActionOnNewScreen(ScreenController newScreen)
    {
        _safranLogo.sprite = _status.Find(x => x.ScreenController == newScreen).Image;
    }

    public void Click()
    {
        StopAllCoroutines();
        _count++;
        if (_count > 4)
        {
            Application.Quit();
        }
        else
        {
            StartCoroutine(ResetCountCoroutine());
        }
    }

    private IEnumerator ResetCountCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _count = 0;
    }
}
