using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Events;
using static Enums;

public class FilterManager : Singleton<FilterManager>   
{
    private UnityEvent _filtersEditedEvent = new UnityEvent();
    public UnityEvent FiltersEditedEvent => _filtersEditedEvent;

    public List<Filter> _filters = new List<Filter>();
    public List<Filter> Filters => _filters;

    public void EditFilter(Filter type, bool add)
    {
        if (add)
        {
            _filters.Add(type);
        }
        else
        {
            _filters.Remove(type);
        }
        _filters.Sort();
        _filtersEditedEvent.Invoke();   
    }
}
