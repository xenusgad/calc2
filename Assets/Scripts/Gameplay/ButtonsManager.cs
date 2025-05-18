using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    private List<GameObject> _slots = new();
    private void Awake()
    {
        for(int i = 1; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).name == "EmptyButtonSlot")
            {
                _slots.Add(transform.GetChild(i).gameObject);
                
            }
        }    
    }
    public void LoadLevel(LevelData _levelData)
    {
        for(int i = 0; i < _slots.Count; i++)
        {
            if(_levelData.buttons[i] != "")
            {
                Instantiate(Resources.Load($"Prefabs/CalcButtons/{_levelData.buttons[i]}"), _slots[i].transform);
            }
        }
    }
}
