using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpaceBottleController : MonoBehaviour, IDropHandler
{
    private RectTransform rectTransform;
    public bool IsTaken;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.TryGetComponent(out BottleController bottleController))
        {
            if (!IsTaken)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
                bottleController.SpaceBottle = this;
                IsTaken = true;
                bottleController.PozSpaceBottle = rectTransform.anchoredPosition;
                Debug.Log("Is not Taken");
            }
            else
            {
                IsTaken = true;
                bottleController.ReturnToSpaceBottle();
                Debug.Log("IsTaken1!");
            }
        }
    }
}
