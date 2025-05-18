using UnityEngine;

public class GameplayCamera : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            TryPressButton();
        }
    }
    
    private void TryPressButton()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
        {
            if(hit.collider.transform.childCount == 1)
            {
                if (hit.collider.transform.GetChild(0).gameObject.GetComponent<CalcButton>())
                {
                    hit.collider.transform.GetChild(0).gameObject.GetComponent<CalcButton>().ButtonPressed();
                }
            }
        }
    }
}
