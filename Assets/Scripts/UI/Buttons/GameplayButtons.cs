using UnityEngine;
using UnityEngine.Events;


public class GameplayButtons : MonoBehaviour
{
    public static UnityEvent ECloseGameplay = new();
    public void CloseGameplay()
    {
        ECloseGameplay.Invoke();
    }
}