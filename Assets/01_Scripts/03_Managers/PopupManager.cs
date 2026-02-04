using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : Singleton<PopupManager>
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TMP_Text _name;   
    [SerializeField] private TMP_Text _description;   
    [SerializeField] private Image _image;   

    private void Awake()
    {
        GameManager.Instance.InitEvent.AddListener(HidePopup);
    }

    public void HidePopup()
    {
        SetContent(null);
    }

    public void SetContent(SiteModel model)
    {
        if (model != null)
        {
            _animator.SetBool("Visible", true);
            _name.text = model.Name;
            _description.text = model.Description;
            _image.sprite= model.Image;
        }
        else
        {
            _animator.SetBool("Visible", false);
        }
    }
}
