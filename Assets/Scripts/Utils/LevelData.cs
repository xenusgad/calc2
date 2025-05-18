using System;
using System.Collections.Generic;

[Serializable]
public class LevelData
{
    public string name;
    public int goal;
    public int maxTurns;
    public List<string> buttons = new();
    public LevelData(List<string> buttons, string name = "Default", int goal = 0, int maxTurns = 0)
    {
        this.name = name;
        this.goal = goal;
        this.maxTurns = maxTurns;
        this.buttons = buttons;
    }
}