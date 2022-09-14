using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalAreaController : MonoBehaviour
{
    [SerializeField] StantionController stantionController;
    public bool IsPlayerInChArea { get; private set; }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<CharacterController>() == null)
            throw new NullReferenceException();
        IsPlayerInChArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsPlayerInChArea = false;
        stantionController.CloseChemicalStation();
    }
}
