using TMPro;
using UnityEngine;

public class WinLostWindow : MonoBehaviour
{
    public static UnityEventString EVictory = new();
    [SerializeField] private TextMeshProUGUI _winLostText;
    [SerializeField] private TextMeshProUGUI _LevelNameText;
    [SerializeField] private TextMeshProUGUI _spentTurnsText;
    [SerializeField] private TextMeshProUGUI _maxTurnsText;
    
    public void Set(bool victory, int spentTurns, LevelData levelData)
    {
        if (victory)
        {
            _winLostText.text = "You Won";
            EVictory.Invoke(levelData.name);
        }
        else
        {
            _winLostText.text = "You Lost";
        }
        _LevelNameText.text = levelData.name;
        _spentTurnsText.text = "Your turns: " + spentTurns.ToString();
        _maxTurnsText.text = "Turns limit: " + levelData.maxTurns.ToString();
    }
}
