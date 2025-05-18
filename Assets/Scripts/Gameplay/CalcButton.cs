using TMPro;
using UnityEngine;

public class CalcButton : MonoBehaviour
{
    public Sprite sprite;
    [SerializeField] private TextMeshProUGUI _display;
    private void Awake()
    {
        _display.text = gameObject.name[..1];
    }
    public void ButtonPressed()
    {
        Calculator.EButtonPressed.Invoke(gameObject.name);
    }
}
