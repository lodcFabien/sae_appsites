using System;
using UnityEngine;
using UnityEngine.Events;

public class SiteButtonController : MonoBehaviour
{
    [SerializeField] private SiteModel _model;
    public SiteModel Model => _model;

    [SerializeField] private GameObject _selectedImage;

    private UnityEvent<SiteButtonController> _siteClicked = new UnityEvent<SiteButtonController>();
    public UnityEvent<SiteButtonController> SiteClicked => _siteClicked;

    private void OnEnable()
    {
        ActionOnFilterEdited();
    }

    private void Awake()
    {
        FilterManager.Instance.FiltersEditedEvent.AddListener(ActionOnFilterEdited);
    }

    private void ActionOnFilterEdited()
    {
        this.gameObject.SetActive(_model.IsOkWithFilters(FilterManager.Instance.Filters));
    }

    public void OnClick()
    {
        SiteClicked.Invoke(this);
    }

    public void SetSelected(bool selected)
    {
        _selectedImage.SetActive(selected);
    }
}
