using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

[CreateAssetMenu(fileName = "SiteModel", menuName = "ScriptableObjects/SiteModel", order = 1)]
public class SiteModel : ScriptableObject
{
    public string Name;
    public Sprite Image;
    public string Description;
    public bool New;
    public bool Buyout;
    public bool Extension;
    public List<JobDirection> JobDirections;
}
