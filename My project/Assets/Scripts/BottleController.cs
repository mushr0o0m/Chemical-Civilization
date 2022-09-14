using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class BottleController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    
    public SpaceBottleController SpaceBottle;
    public Vector2 PozSpaceBottle;
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform jetPoz;

    private RectTransform rectTransform;
    [NonSerialized] public Bottle bottle;
    private CanvasGroup canvasGroup;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        PozSpaceBottle = SpaceBottle.GetComponent<RectTransform>().anchoredPosition;
        bottle = GetComponent<Bottle>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        SpaceBottle.IsTaken = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    public void ReturnToSpaceBottle()
    {
        rectTransform.anchoredPosition = PozSpaceBottle;
        SpaceBottle.IsTaken = true;
    }

    public IEnumerator PourContent(BottleController targetBottle)
    {
        var tgRectTransform = targetBottle.GetComponent<RectTransform>();
        var tgPoz = tgRectTransform.anchoredPosition;

        rectTransform.anchoredPosition = new Vector2(tgPoz.x - tgRectTransform.sizeDelta.x - 20, tgPoz.y + jetPoz.anchoredPosition.y + 50);
        GetComponent<Animator>().SetBool("IsReadyTwist", true);
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().SetBool("IsReadyTwist", false);
        ReturnToSpaceBottle();
    }

    public IEnumerator PourContent(Coal targetBottle)
    {
        var tgRectTransform = targetBottle.GetComponent<RectTransform>();
        var tgPoz = tgRectTransform.anchoredPosition;

        rectTransform.anchoredPosition = new Vector2(tgPoz.x - tgRectTransform.sizeDelta.x - 20, tgPoz.y + jetPoz.anchoredPosition.y + 50);
        GetComponent<Animator>().SetBool("IsReadyTwist", true);
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().SetBool("IsReadyTwist", false);
        ReturnToSpaceBottle();
    }


    public void OnDrop(PointerEventData eventData) //Спкойной ночи. Здесь дальше стоит сделать смешение реактивов
    {
        if(eventData.pointerDrag != null && eventData.pointerDrag.TryGetComponent(out BottleController bottleController))
        {
            StartCoroutine(bottleController.PourContent(this));
            if(!bottle.IsBottleFully) bottle.ContentValue += 1/4f;
            bottleController.SpaceBottle.IsTaken = true;

            Debug.Log("IsTaken!");
        }
    }
}
