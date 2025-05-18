using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Languages{ENG, RUS};
public class GameEntryPoint
{
    private static GameEntryPoint _instance;
    public static UnityEventLevelData EStartLevel = new();
    private Coroutines _coroutines;
    private UIRootView _uiRoot;
    private SaveManager _saveManager;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void AutostarGame()
    {
        _instance = new GameEntryPoint();
        _instance.RunGame();
    }
    private GameEntryPoint()
    {
        _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
        Object.DontDestroyOnLoad(_coroutines.gameObject);
        _uiRoot = Object.Instantiate(Resources.Load<UIRootView>("Prefabs/UIRoot"));
        Object.DontDestroyOnLoad(_uiRoot.gameObject);
        _saveManager = Object.Instantiate(Resources.Load<SaveManager>("Prefabs/SaveManager"));
        Object.DontDestroyOnLoad(_saveManager.gameObject);
        var buttons = Object.Instantiate(Resources.Load<LoadButtons>("Prefabs/Buttons"));
        Object.DontDestroyOnLoad(buttons.gameObject);
        buttons.Load();
    }
    private void RunGame()
    {
        _uiRoot.ShowLoadingScreen();
        _coroutines.StartCoroutine(LoadBootScene());
        SubscribeOnMainEvents();
    }
    private IEnumerator GoToScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            yield return LeaveAnyScene();
            yield return LoadScene(sceneName);
            yield return null;
            RunAnyScene();
        }
    }
    private IEnumerator LeaveAnyScene()
    {
        yield return null;
        switch (SceneManager.GetActiveScene().name)
        {
            case "Menu":
            Object.FindAnyObjectByType<MenuEntryPoint>().LeaveScene();
            break;
            case "Gameplay":
            Object.FindAnyObjectByType<GameplayEntryPoint>().LeaveScene();
            break;
            case "Redactor":
            Object.FindAnyObjectByType<RedactorEntryPoint>().LeaveScene();
            break;
        }
    }
    private void RunAnyScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Menu":
            Object.FindAnyObjectByType<MenuEntryPoint>().Run();
            break;
            case "Gameplay":
            Object.FindAnyObjectByType<GameplayEntryPoint>().Run();
            break;
            case "Redactor":
            Object.FindAnyObjectByType<RedactorEntryPoint>().Run();
            break;
        }
    }
    private void OpenMenu()
    {
        _coroutines.StartCoroutine(GoToScene("Menu"));
    }
    private void OpenRedactor()
    {
        _coroutines.StartCoroutine(GoToScene("Redactor"));
    }
    private void OpenGameplay(LevelData levelData)
    {
        _coroutines.StartCoroutine(GoToScene("Gameplay"));
        var currentLevelInfoToDestroy = Object.FindFirstObjectByType<CurrentLevelInfo>();
        if (currentLevelInfoToDestroy != null)
        {
            Object.Destroy(currentLevelInfoToDestroy.gameObject);
        }
        var currentLevelInfo = Object.Instantiate(Resources.Load("Prefabs/CurrentLevelInfo") as GameObject);
        Object.DontDestroyOnLoad(currentLevelInfo);
        currentLevelInfo.GetComponent<CurrentLevelInfo>().levelData = levelData;
    }
    private IEnumerator LoadBootScene()
    {
        yield return SceneManager.LoadSceneAsync("Boot");
        _coroutines.StartCoroutine(GoToScene("Menu"));
    }
    private IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
    private void SubscribeOnMainEvents()
    {
        RedactorButtons.ECloseRedactor.AddListener(OpenMenu);
        GameplayButtons.ECloseGameplay.AddListener(OpenMenu);
        MenuButtons.EOpenRedactor.AddListener(OpenRedactor);
        EStartLevel.AddListener(OpenGameplay);
        MenuButtons.EQuitGame.AddListener(CloseGame);
    }
    private void CloseGame()
    {
        Application.Quit();
    }
}