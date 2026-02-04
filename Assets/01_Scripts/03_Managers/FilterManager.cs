using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Events;
using static Enums;

public class FilterManager : Singleton<FilterManager>   
{
    private UnityEvent _filtersEditedEvent = new UnityEvent();
    public UnityEvent FiltersEditedEvent => _filtersEditedEvent;

    private Dictionary<FilterType, bool> _filters = new Dictionary<FilterType, bool>();

    public void EditFilter(FilterType type, bool value)
    {
        if (!_filters.ContainsKey(type))
        {
            _filters.Add(type, value);
        }
        else
        {
            _filters[type] = value;
        }
    }
}
