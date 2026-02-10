using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ZoneButtonController : NewScreenButtonController
{
    [SerializeField] private List<SiteModel> _associatedSites = new List<SiteModel>();
    public List<SiteModel> AssociatedSites => _associatedSites;

    [SerializeField] private TMP_Text _countText;
    [SerializeField] private RectTransform _rectTransform;

    [NonSerialized] public int MaxSitesCount = 0;

    private float _currentSize;
    private float _minSize = 90;
    private float _maxSize = 250;
    private int _count = 0;

    private void Awake()
    {
        FilterManager.Instance.FiltersEditedEvent.AddListener(ActionOnFilterEdited);
        _currentSize = _minSize;
    }

    private void ActionOnFilterEdited()
    {
        _count = 0;
        foreach (SiteModel site in _associatedSites) 
        {
            if (site.IsOkWithFilters(FilterManager.Instance.Filters))
            {
                _count++;
            }
        }
        _countText.text = _count.ToString();
    }

    private void Update()
    {
        float newSize = ((float)_count).Remap(0, MaxSitesCount, _minSize, _maxSize);
        _currentSize = Mathf.Lerp(_currentSize, newSize, Time.deltaTime * 5f);
        _rectTransform.sizeDelta = new Vector2(_currentSize, _currentSize);
    }
}
