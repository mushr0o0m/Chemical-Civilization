using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StantionController : MonoBehaviour
{
    [SerializeField] GameObject ChemicalPanel;
    [SerializeField] ChemicalAreaController chemicalAreaController;
    public bool IsChemicalStationOpen { get; private set; }
    public void OpenChemicalStation()
    {
        if (ChemicalPanel != null && !ChemicalPanel.activeSelf)
        {
            ChemicalPanel.SetActive(true);
            IsChemicalStationOpen = true;
        }
    }
    public void CloseChemicalStation()
    {
        if (ChemicalPanel != null && ChemicalPanel.activeSelf)
        {
            ChemicalPanel.SetActive(false);
            IsChemicalStationOpen = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && chemicalAreaController.IsPlayerInChArea && !IsChemicalStationOpen)
        {
            OpenChemicalStation();
        }
        else if(Input.GetKeyUp(KeyCode.E) && chemicalAreaController.IsPlayerInChArea && IsChemicalStationOpen)
        {
            CloseChemicalStation();
        }
    }
}
