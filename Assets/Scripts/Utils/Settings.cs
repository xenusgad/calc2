using System;
using UnityEngine;

[Serializable]
public class Settings
{
    [Range(0,1)] public double volume;
    public Languages language;
    public Settings()
    {
        volume = 0.5;
        language = Languages.ENG;
    }
}
