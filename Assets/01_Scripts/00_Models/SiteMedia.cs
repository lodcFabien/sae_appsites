using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[Serializable]
public class SiteMedia
{
    public Sprite Image;
    public SiteVideo Video;

    public bool IsVideo()
    {
        return Video.VideoClip != null;
    }

    public Sprite GetThumbnail()
    {
        if (IsVideo())
        {
            return Video.Thumbnail;
        }
        else
        {
            return Image;
        }
    }
}
