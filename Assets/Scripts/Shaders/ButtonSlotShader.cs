using UnityEngine;

public class ButtonSlotShader : MonoBehaviour
{
    [SerializeField] private Material defaultButtonSlotShader;
    [SerializeField] private Material selectedButtonSlotShader;
    [SerializeField] private Color defaulutColor;
    [SerializeField] private Color selectedColor;
    void Start()
    {
        SetDefault();
    }

    public void SetDefault()
    {
        gameObject.GetComponent<Renderer>().material = defaultButtonSlotShader;
    }

    public void SetSelected()
    {
        gameObject.GetComponent<Renderer>().material = selectedButtonSlotShader;
    }
}
