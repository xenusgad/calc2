using System;
using System.Collections.Generic;

[Serializable]
public class CompletedLevels
{
    public List<string> levels;
    public CompletedLevels()
    {
        levels = new List<string>();
    }
}
