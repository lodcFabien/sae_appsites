using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ZoneScreenController : ScreenController
{
    [SerializeField] private List<SiteButtonController> _siteButtons = new List<SiteButtonController>();

    protected override void Awake()
    {
        base.Awake();
        _siteButtons.ForEach(x => x.SiteClicked.AddListener(ActionOnSiteClicked));
        PopupManager.Instance.PopupQuit.AddListener(ActionOnPopupQuit);
    }

    private void ActionOnPopupQuit()
    {
        ActionOnSiteClicked(null);
    }

    protected override void ActionOnNewScreen(ScreenController newScreen)
    {
        base.ActionOnNewScreen(newScreen);
        ActionOnSiteClicked(null);
    }

    private void ActionOnSiteClicked(SiteButtonController clickedSite)
    {
        if (clickedSite)
        {
            PopupManager.Instance.SetContent(clickedSite.Model);
        }

        _siteButtons.ForEach(x => x.SetSelected(x == clickedSite));
    }
}
