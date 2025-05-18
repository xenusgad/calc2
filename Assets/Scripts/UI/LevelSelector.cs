using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    private List<LevelData> levelsData = new();
    private CompletedLevels completedLevels;
    private void OnEnable()
    {
        if(transform.childCount != 0)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        completedLevels = FindFirstObjectByType<SaveManager>().completedLevels;
        levelsData = FindFirstObjectByType<SaveManager>().LoadLevels();
        var prefab = Resources.Load("Prefabs/SelectorImage");
        foreach (var levelData in levelsData)
        {
            var levelImage = Instantiate(prefab, transform);
            levelImage.GetComponent<SelectorImage>().DrawLevelInfo(levelData, completedLevels);
        }
    }

}
