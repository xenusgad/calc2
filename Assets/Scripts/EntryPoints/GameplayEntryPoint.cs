using UnityEngine;

public class GameplayEntryPoint : MonoBehaviour, IEntryPoint
{
    private UIRootView _uiRoot;
    private ButtonsSpawner buttonsSpawner;
    private CurrentLevelInfo currentLevelInfo;
    public void Run()
    {
        _uiRoot = FindFirstObjectByType<UIRootView>();
        _uiRoot.HideAll();
        _uiRoot.ShowPopUps();
        _uiRoot.ShowGameplayWindow();
        _uiRoot.ShowGameplayExitButton();
        buttonsSpawner = FindFirstObjectByType<ButtonsSpawner>();
        currentLevelInfo = FindFirstObjectByType<CurrentLevelInfo>();
        buttonsSpawner.SpawnButtons(currentLevelInfo.levelData.buttons);
    }
    public void LeaveScene()
    {
        _uiRoot.HideAll();
        _uiRoot.ShowLoadingScreen();
    }
}
