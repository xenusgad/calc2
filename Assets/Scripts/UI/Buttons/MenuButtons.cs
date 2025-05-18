using UnityEngine;
using UnityEngine.Events;


public class MenuButtons : MonoBehaviour
{
    public static UnityEvent EQuitGame = new();
    public static UnityEvent EOpenRedactor = new();
    public static UnityEvent EOpenSettings = new();
    public static UnityEvent ECloseSettings = new();
    public static UnityEvent ESaveGame = new();
    public static UnityEvent EOpenLevelSelector = new();
    public static UnityEvent ECloseSelector = new();
    public void QuitGame()
    {
        EQuitGame.Invoke();
    }
    public void OpenSettings()
    {
        EOpenSettings.Invoke();
    }
    public void CloseSettings()
    {
        ECloseSettings.Invoke();
    }
    public void SaveGame()
    {
        ESaveGame.Invoke();
    }
    public void OpenRedactor()
    {
        EOpenRedactor.Invoke();
    }
    public void OpenLevelSelector()
    {
        EOpenLevelSelector.Invoke();
    }
    public void CloseSelector()
    {
        ECloseSelector.Invoke();
    }
}
