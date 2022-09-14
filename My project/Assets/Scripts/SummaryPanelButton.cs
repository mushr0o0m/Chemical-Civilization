using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummaryPanelButton : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    public void OnPressButton()
    {
        Panel.SetActive(!Panel.activeSelf);
    }
}
