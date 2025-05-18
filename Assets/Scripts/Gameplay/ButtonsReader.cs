using System.Collections.Generic;
using UnityEngine;

public class ButtonsReader : MonoBehaviour
{
    public List<string> ReadButtons()
    {
        List<string> buttons = new();
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "ButtonSlotPrefab")
            {
                buttons.Add("");
                if(transform.GetChild(i).childCount > 1)
                {
                    buttons[^1] = transform.GetChild(i).GetChild(1).name[..1];
                }
            }
        }
        return buttons;
    }
}
