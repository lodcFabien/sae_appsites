using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ZoneButtonController : NewScreenButtonController
{
    [SerializeField] private List<SiteModel> _associatedSites = new List<SiteModel>();
    [SerializeField] private TMP_Text _countText;

    private void Awake()
    {
        FilterManager.Instance.FiltersEditedEvent.AddListener(ActionOnFilterEdited);
    }

    private void ActionOnFilterEdited()
    {
        int count = 0;
        foreach (SiteModel site in _associatedSites) 
        {
            if (site.IsOkWithFilters(FilterManager.Instance.Filters))
            {
                count++;
            }
        }
        _countText.text = count.ToString();
    }
}
