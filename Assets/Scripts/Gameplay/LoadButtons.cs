using System.Collections.Generic;
using UnityEngine;

public class LoadButtons : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    public void Load()
    {
        var objs = Resources.LoadAll("Prefabs/CalcButtons");
        for(int i = 0; i < objs.Length; i++)
        {
            buttons.Add(objs[i] as GameObject);
        }
    }
}
