using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RedactorCamera : MonoBehaviour
{
    private bool _dragging = false;
    private GameObject _draggingObject;
    [SerializeField] Quaternion buttonRotation;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(_dragging)
            {
                DragButton();
            }
            else
            {
                string buttonName = TryTakeButton();
                if(buttonName != null)
                {
                    _draggingObject = Instantiate
                    (
                        Resources.Load($"Prefabs/CalcButtons/{buttonName}") as GameObject,
                        new Vector3(100, 100, 100),
                        buttonRotation
                    );
                    _draggingObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                }
            }
        }
        else if(Input.GetMouseButtonUp(0) && _dragging)
        {
            TryInsertButton();
        }
    }

    private void DragButton()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, 50))
        {
            if (hit.collider.gameObject.name == "ButtonSlidingSurface")
            {
                _draggingObject.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
        }
    }
    private string TryTakeButton()
    {
        if(IsMousOverUI() && _dragging == false)
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;
            List<RaycastResult> raycastResults = new();
            EventSystem.current.RaycastAll(pointerEventData, raycastResults);
            for(int i = 0; i < raycastResults.Count; i++)
            {
                if (raycastResults[i].gameObject.name == "RedactorSpritePrefab(Clone)")
                {
                    _dragging = true;
                    return raycastResults[i].gameObject.GetComponent<Image>().sprite.ToString()[..1];
                }
            }
        }
        return null;
    }
    private bool IsMousOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    private void TryInsertButton()
    {
        var buttonSlot = CheckForButtonEmptySlot(DrawButtonRay());
        if(buttonSlot != null)
        {
            _draggingObject.transform.SetParent(buttonSlot.transform, true);
            _draggingObject.transform.position = buttonSlot.transform.position;
        }
        else
        {
            Destroy(_draggingObject);
        }
        _dragging = false;
    }
    private Ray DrawButtonRay()
    {
        Ray ray = new Ray(_draggingObject.transform.position, Vector3.forward);
        return ray;
    }
    private GameObject CheckForButtonEmptySlot(Ray ray)
    {
        if(Physics.Raycast(ray, out RaycastHit hit, 100))
        {
            if(hit.collider.gameObject.name == "ButtonSlotPrefab")
            {
                return hit.collider.gameObject;
            }
        }
        return null;
    }
}
