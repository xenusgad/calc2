using TMPro;
using UnityEngine;

public class SelectorImage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelNameTXT;
    [SerializeField] private TextMeshProUGUI goalTXT;
    [SerializeField] private TextMeshProUGUI maxTurnsTXT;
    [SerializeField] private TextMeshProUGUI buttonsTXT;
    [SerializeField] private GameObject checkMark;
    private LevelData storedLevelData;
    public void DrawLevelInfo(LevelData levelData, CompletedLevels completedLevels)
    {
        checkMark.SetActive(false);
        for (int i = 0; i < completedLevels.levels.Count; i++)
        {
            if (completedLevels.levels[i] == levelData.name)
            {
                checkMark.SetActive(true);
            }
        }
        storedLevelData = levelData;
        levelNameTXT.text = levelData.name;
        goalTXT.text = "Goal: " + levelData.goal.ToString();
        maxTurnsTXT.text = "Max turns: " + levelData.maxTurns.ToString();
        buttonsTXT.text = "Buttons: ";
        for(int i = 0; i < levelData.buttons.Count; i++)
        {
            if(levelData.buttons[i] != "")
            {
                buttonsTXT.text += levelData.buttons[i][..1] + ", ";
            }
        }
        buttonsTXT.text = buttonsTXT.text.Substring(0, buttonsTXT.text.Length - 2) + ".";
    }

    public void StartLevel()
    {
        GameEntryPoint.EStartLevel.Invoke(storedLevelData);
    }
}
