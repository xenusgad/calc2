using UnityEngine;

public class RedactorEntryPoint : MonoBehaviour, IEntryPoint
{
    private UIRootView _uiRoot;
    public void Run()
    {
        _uiRoot = FindFirstObjectByType<UIRootView>();
        _uiRoot.HideAll();
        _uiRoot.ShowPopUps();
        _uiRoot.ShowRedactor();
        _uiRoot.ShowRedactorExitButton();
    }

    public void LeaveScene()
    {
        _uiRoot.HideAll();
        _uiRoot.ShowLoadingScreen();
    }
}
