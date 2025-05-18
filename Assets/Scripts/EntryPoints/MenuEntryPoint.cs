using UnityEngine;

public class MenuEntryPoint: MonoBehaviour, IEntryPoint
{
    private UIRootView _uiRoot;

    public void Run()
    {
        _uiRoot = FindFirstObjectByType<UIRootView>();
        _uiRoot.HideAll();
        _uiRoot.ShowScreens();
        _uiRoot.ShowMenuScreen();
        MenuButtons.EOpenSettings.AddListener(OpenSettings);
        MenuButtons.ECloseSettings.AddListener(CloseSettings);
        MenuButtons.EOpenLevelSelector.AddListener(OpenLevelSelector);
        MenuButtons.ECloseSelector.AddListener(CloseLevelSelector);
    }

    public void OpenSettings()
    {
        _uiRoot.ShowPopUps();
        _uiRoot.ShowSettingsPopUp();
    }
    public void CloseSettings()
    {
        FindFirstObjectByType<SaveManager>().Load();
        _uiRoot.HideSettingsPopUp();
        _uiRoot.HidePopUps();
    }
    public void OpenLevelSelector()
    {
        _uiRoot.ShowPopUps();
        _uiRoot.ShowLevelSelector();
    }
    public void CloseLevelSelector()
    {
        _uiRoot.HideLevelSelector();
        _uiRoot.HidePopUps();
    }
    public void LeaveScene()
    {
        _uiRoot.HideAll();
        _uiRoot.ShowLoadingScreen();
    }
}
