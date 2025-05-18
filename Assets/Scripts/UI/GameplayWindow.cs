using TMPro;
using UnityEngine;

public class GameplayWindow : MonoBehaviour
{
    private UIRootView _uiRoot;
    [SerializeField] private WinLostWindow _winLostWindow;
    [SerializeField] private TextMeshProUGUI _levelName;
    [SerializeField] private TextMeshProUGUI _goal;
    [SerializeField] private TextMeshProUGUI _turns;
    private LevelData _levelData;
    private int currentTurns;
    private void Awake()
    {
        _uiRoot = FindFirstObjectByType<UIRootView>();
        Calculator.ECalculationPerformed.AddListener(OnCalculation);
    }
    private void OnEnable()
    {
        currentTurns = 0;
        _levelData = FindAnyObjectByType<CurrentLevelInfo>().levelData;
        _levelName.text = _levelData.name;
        _goal.text = "Goal: " + _levelData.goal.ToString();
        _turns.text = "Turns: " + currentTurns.ToString() + "/" + _levelData.maxTurns.ToString();
    }

    private void OnCalculation(long result)
    {
        currentTurns++;
        _turns.text = "Turns: " + currentTurns.ToString() + "/" + _levelData.maxTurns.ToString();
        if (currentTurns > _levelData.maxTurns)
        {
            return;
        }
        if (currentTurns == _levelData.maxTurns)
        {
            if(result == _levelData.goal)
            {
                Win();
            }
            else
            {
                Lost();
            }
        }
        else if(result == _levelData.goal)
        {
            Win();
        }
    }
    private void Win()
    {
        _uiRoot.ShowWinLostWindow();
        _winLostWindow.Set(true, currentTurns, _levelData);
    }
    private void Lost()
    {
        _uiRoot.ShowWinLostWindow();
        _winLostWindow.Set(false, currentTurns, _levelData);
    }
}
