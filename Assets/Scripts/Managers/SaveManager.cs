using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager: MonoBehaviour
{
    private Storage _storage;
    public Settings settings;
    public CompletedLevels completedLevels;
    private void Start()
    {
        MenuButtons.ESaveGame.AddListener(SaveSettings);
        _storage = new Storage();
        Load();
        WinLostWindow.EVictory.AddListener(SaveComletedLevels);
    }
    public void SaveSettings()
    {
        _storage.SaveProfile(settings, "settings.save");
    }
    private void SaveComletedLevels(string level)
    {
        for(int i = 0; i < completedLevels.levels.Count; i++)
        {
            if(completedLevels.levels[i] == level)
            {
                return;
            }
        }
        completedLevels.levels.Add(level);
        _storage.SaveProfile(completedLevels, "completedLevels.save");
    }
    public void Load()
    {
        settings = (Settings) _storage.LoadProfile(new Settings(), "settings.save");
        completedLevels = (CompletedLevels) _storage.LoadProfile(new CompletedLevels(), "completedLevels.save");
    }
    public void CreateLevel(LevelData levelData)
    {
        _storage.SaveLevel(levelData, levelData.name + ".save");
    }
    public List<LevelData> LoadLevels()
    {
        List<LevelData> tempLevelsData = new();
        foreach(string file in Directory.EnumerateFiles(Application.dataPath + "/Resources/Levels"))
        {
            if(file.Substring(file.LastIndexOf(".") + 1, 4) == "save")
            {
                tempLevelsData.Add((LevelData) _storage.LoadLevel(file));
            }
        }
        return tempLevelsData;
    }
}
