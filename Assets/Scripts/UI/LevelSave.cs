using System;
using TMPro;
using UnityEngine;

public class LevelSave : MonoBehaviour
{
    public TMP_InputField nameLevel;
    public TMP_InputField goal;
    public TMP_InputField maxTurns;
    public LevelData levelData;
    private SaveManager _saveManager;
    private void Awake()
    {
        _saveManager = FindFirstObjectByType<SaveManager>();
    }
    public void SaveLevel()
    {
        levelData = new LevelData(
        FindFirstObjectByType<ButtonsReader>().ReadButtons(),
        nameLevel.text,
        Convert.ToInt32(goal.text),
        Convert.ToInt32(maxTurns.text));
        _saveManager.CreateLevel(levelData);
    }
}
