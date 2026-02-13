using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
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
    public List<SiteMedia> Medias;
    public Filter SiteTypology;
    public List<SiteJob> Jobs;
    public Sprite Flag;
    public Sprite ZoneBackground;

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

    public List<Sprite> GetThumbnails()
    {
        List<Sprite> thumbnails = new List<Sprite>();

        foreach (SiteMedia media in Medias) 
        {
            if (media.IsVideo())
            {
                thumbnails.Add(media.Video.Thumbnail);
            }
            else
            {
                thumbnails.Add(media.Image);
            }
        }

        return thumbnails;
    }
}
