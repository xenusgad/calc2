using UnityEngine;

public class ButtonColorChange : MonoBehaviour
{
    private ButtonSlotShader buttonSlotShader;
    void Start()
    {
        buttonSlotShader = transform.parent.GetComponent<ButtonSlotShader>();
    }
    private void OnTriggerEnter(Collider other)
    {
        buttonSlotShader.SetSelected();
    }
    private void OnTriggerExit(Collider other)
    {
        buttonSlotShader.SetDefault();
    }
}
