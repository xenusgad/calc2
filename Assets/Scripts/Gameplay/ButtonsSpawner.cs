using System.Collections.Generic;
using UnityEngine;

public class ButtonsSpawner : MonoBehaviour
{
    [SerializeField] private Quaternion buttonsRotation;
    public void SpawnButtons(List<string> buttons)
    {
        int j = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "EmptyButtonSlot")
            {
                if(buttons[j] != "")
                {
                    var curButton = Instantiate
                    (
                        Resources.Load($"Prefabs/CalcButtons/{buttons[j]}") as GameObject,
                        Vector3.zero,
                        buttonsRotation
                    );
                    curButton.transform.SetParent(transform.GetChild(i).transform, false);
                    curButton.transform.localScale = new Vector3(1.2f, 9f, 1.2f);
                    curButton.name = curButton.name.Substring(0, 1);
                }
                j++;
            }
        }
    }
}
