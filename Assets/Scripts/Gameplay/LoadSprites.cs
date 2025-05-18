using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadSprites : MonoBehaviour
{
    private List<GameObject> buttons = new List<GameObject>();
    private void Awake()
    {
        buttons = FindFirstObjectByType<LoadButtons>().buttons;
        var spritePrefab = Resources.Load("Prefabs/RedactorSpritePrefab");
        foreach (var button in buttons)
        {
            var tmp = Instantiate(spritePrefab, transform);
            tmp.GetComponent<Image>().sprite = button.GetComponent<CalcButton>().sprite;
        }
    }
}
