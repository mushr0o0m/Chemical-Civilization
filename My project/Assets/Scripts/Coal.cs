using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Coal : MonoBehaviour, IDropHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Text Helper;
    [SerializeField] private Text Name;
    [SerializeField] private GameObject ButtomGo;
    [SerializeField] private InterfaceController InterfaceController;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData) //�������� ����. ����� ������ ����� ������� �������� ���������
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.TryGetComponent(out BottleController bottleController)
            && bottleController.bottle.ContentValue >= 0.9)
        {
            StartCoroutine(bottleController.PourContent(this));
            InterfaceController.AddCredibility(0.5f);
            ButtomGo.SetActive(true);
            Name.text = "�������������� �����";
            Helper.text = "������. ������� ������������� �����!";
            bottleController.SpaceBottle.IsTaken = true;
        }
    }
}
