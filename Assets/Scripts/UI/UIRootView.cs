using UnityEngine;

public class UIRootView : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private GameObject _screens;
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private GameObject _popUps;
    [SerializeField] private GameObject _settingsPopUp;
    [SerializeField] private GameObject _redactorPopUp;
    [SerializeField] private GameObject _redactorExitButton;
    [SerializeField] private GameObject _gameplayExitButton;
    [SerializeField] private GameObject _levelSelector;
    [SerializeField] private GameObject _gameplayPopUp;
    [SerializeField] private GameObject _winLostPopUp;

    private void Awake()
    {
        //HideAll();
    }
    public void ShowLoadingScreen()
    {
        _loadingScreen.SetActive(true);
    }
    public void HideLoadingScreen()
    {
        _loadingScreen.SetActive(false);
    }
    public void ShowScreens()
    {
        _screens.SetActive(true);
    }
    public void HideScreens()
    {
        _screens.SetActive(false);
    }
    public void ShowMenuScreen()
    {
        _menuScreen.SetActive(true);
    }
    public void HideMenuScreen()
    {
        _menuScreen.SetActive(false);
    }
    public void ShowSettingsPopUp()
    {
        _settingsPopUp.SetActive(true);
    }
    public void HideSettingsPopUp()
    {
        _settingsPopUp.SetActive(false);
    }
    public void ShowPopUps()
    {
        _popUps.SetActive(true);
    }
    public void HidePopUps()
    {
        _popUps.SetActive(false);
    }
    public void ShowRedactor()
    {
        _redactorPopUp.SetActive(true);
    }
    public void HideRedactor()
    {
        _redactorPopUp.SetActive(false);
    }
    public void MoveRedactor()
    {
        _redactorPopUp.transform.position = new Vector3
        (
        _redactorPopUp.transform.position.x * -1,
        _redactorPopUp.transform.position.y,
        _redactorPopUp.transform.position.z
        );
    }
    public void ShowRedactorExitButton()
    {
        _redactorExitButton.SetActive(true);
    }
    public void HideRedactorExitButton()
    {
        _redactorExitButton.SetActive(false);
    }
    public void ShowGameplayExitButton()
    {
        _gameplayExitButton.SetActive(true);
    }
    public void HideGameplayExitButton()
    {
        _gameplayExitButton.SetActive(false);
    }
    public void ShowLevelSelector()
    {
        _levelSelector.SetActive(true);
    }
    public void HideLevelSelector()
    {
        _levelSelector.SetActive(false);
    }
    public void ShowGameplayWindow()
    {
        _gameplayPopUp.SetActive(true);
    }
    public void HideGameplayWindow()
    {
        _gameplayPopUp.SetActive(false);
    }
    public void ShowWinLostWindow()
    {
        _winLostPopUp.SetActive(true);
    }
    public void HideWinLostWindow()
    {
        _winLostPopUp.SetActive(false);
    }
    public void HideAll()
    {
        _loadingScreen.SetActive(false);
        _settingsPopUp.SetActive(false);
        _redactorPopUp.SetActive(false);
        _redactorExitButton.SetActive(false);
        _popUps.SetActive(false);
        _menuScreen.SetActive(false);
        _screens.SetActive(false);
        _levelSelector.SetActive(false);
        _gameplayPopUp.SetActive(false);
        _gameplayExitButton.SetActive(false);
        _winLostPopUp.SetActive(false);
    }
}
