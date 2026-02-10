using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : ScreenController
{
    [SerializeField] private List<ZoneButtonController> _buttons = new List<ZoneButtonController>();

    protected override void Awake()
    {
        base.Awake();
        _buttons.ForEach(x=> x.MaxSitesCount= GetMaxSite());
    }

    public int GetMaxSite()
    {
        int maxSites = 0;
        foreach (ZoneButtonController button in _buttons)
        {
            if (button.AssociatedSites.Count > maxSites)
            {
                maxSites = button.AssociatedSites.Count;
            }
        }

        return maxSites;
    }

}
