using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Storage
{
    private string _filePath;
    private string _levelsFilePath;
    private BinaryFormatter _formatter;
    public Storage()
    {
        var directory = Application.persistentDataPath + "/saves";
        if(!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        var levelsDirectory = Application.dataPath + "/Resources/Levels";
        if(!Directory.Exists(levelsDirectory))
        {
            Directory.CreateDirectory(levelsDirectory);
        }
        _filePath = directory + "/";
        _levelsFilePath = levelsDirectory + "/";
        _formatter = new BinaryFormatter();
    }
    public object LoadProfile(object settings, string fileName)
    {
        string fullFilePath = _filePath + fileName;
        if (!File.Exists(fullFilePath))
        {
            if(settings != null)
            {
                SaveProfile(settings, fileName);
                return settings;
            }
        }
        var file = File.Open(fullFilePath, FileMode.Open);
        var savedData = _formatter.Deserialize(file);
        file.Close();
        return savedData;
    }
    public void SaveProfile(object obj, string fileName)
    {
        var file = File.Create(_filePath + fileName);
        _formatter.Serialize(file, obj);
        file.Close();
    }
    public void SaveLevel(object level, string fileName)
    {
        var file = File.Create(_levelsFilePath + fileName);
        _formatter.Serialize(file, level);
        file.Close();
    }
    public object LoadLevel(string fullFilePath)
    {
        object tempLevelData = new();
        if (File.Exists(fullFilePath))
        {
            var file = File.Open(fullFilePath, FileMode.Open);
            tempLevelData = _formatter.Deserialize(file);
            file.Close();
            return tempLevelData; 
        }
        Debug.Log($"File{fullFilePath} does not exist");
        return null;
    }
}
