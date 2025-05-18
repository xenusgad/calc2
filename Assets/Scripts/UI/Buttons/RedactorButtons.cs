using UnityEngine;
using UnityEngine.Events;
public class RedactorButtons : MonoBehaviour
{
    public static UnityEvent ECloseRedactor = new UnityEvent();
    public void CloseRedactor()
    {
        ECloseRedactor.Invoke();
    }
}
