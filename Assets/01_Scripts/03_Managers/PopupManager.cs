using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopupManager : Singleton<PopupManager>
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TMP_Text _name;   
    [SerializeField] private TMP_Text _description;   
    [SerializeField] private Image _image;   
    [SerializeField] private Transform _jobButtonContainer;   
    [SerializeField] private PopupJobButtonController _jobButtonPrefab;
    [SerializeField] private GameObject _imageButtons;

    private List<PopupJobButtonController> _spawnedJobButtons = new List<PopupJobButtonController>();
    private List<Sprite> _images = new List<Sprite>();
    private int _imageIndex = 0;

    private UnityEvent _popupQuit = new UnityEvent();
    public UnityEvent PopupQuit => _popupQuit;

    private void Awake()
    {
        GameManager.Instance.InitEvent.AddListener(HidePopup);
    }

    // call from button
    public void HidePopup()
    {
        SetContent(null);
        _popupQuit.Invoke();
    }

    public void SetContent(SiteModel model)
    {
        if (model != null)
        {
            _animator.SetBool("Visible", true);
            _name.text = model.Name;
            AddJobButtons(model);
            _images = model.Images;
            _imageButtons.SetActive(_images.Count > 1);
            _imageIndex = 0;
            SetImage();
        }
        else
        {
            _animator.SetBool("Visible", false);
        }
    }

    private void AddJobButtons(SiteModel model)
    {
        _spawnedJobButtons.ForEach(x => Destroy(x.gameObject));
        _spawnedJobButtons.Clear();
        PopupJobButtonController currentButton;
        foreach (SiteJob job in model.Jobs)
        {
            currentButton = Instantiate(_jobButtonPrefab, _jobButtonContainer);
            currentButton.Init(job);
            _spawnedJobButtons.Add(currentButton);
        }

        _spawnedJobButtons.Find(x => FilterManager.Instance.Filters.Contains(x.Job.Type)).Click();
    }

    public void SetSelectedJob(PopupJobButtonController clickedButton)
    {
        _spawnedJobButtons.ForEach(x => x.SetSelected(x == clickedButton));
        _description.text = clickedButton.Job.Description;
    }

    public void ChangeImage(bool right)
    {
        if (right)
        {
            _imageIndex++;
            if(_imageIndex > _images.Count -1)
            {
                _imageIndex = 0;
            }
        }
        else
        {
            _imageIndex--;
            if(_imageIndex < 0)
            {
                _imageIndex = _images.Count - 1;
            }
        }
        SetImage();
    }

    public void SetImage()
    {
        _image.sprite = _images[_imageIndex];
    }

}
