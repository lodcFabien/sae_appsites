using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

[Serializable]
public class SiteJob
{
    public Filter Type;
    [TextArea(10, 100)]
    public string Description;
}

[CreateAssetMenu(fileName = "SiteModel", menuName = "ScriptableObjects/SiteModel", order = 1)]
public class SiteModel : ScriptableObject
{
    public string Name;
    public List<Sprite> Images;
    public Filter SiteTypology;
    public List<SiteJob> Jobs;

    public bool IsOkWithFilters(List<Filter> filters)
    {
        bool typologyOk = filters.Contains(SiteTypology);
        bool jobOk = false;

        foreach(SiteJob job in Jobs)
        {
            if (filters.Contains(job.Type))
            {
                jobOk = true;
            }
        }

        return typologyOk && jobOk;
    }
}
