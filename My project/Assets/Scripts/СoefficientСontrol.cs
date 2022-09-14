using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class СoefficientСontrol : MonoBehaviour
{
    [SerializeField] private Text CoeffField;  
    [SerializeField] private Button Up;
    [SerializeField] private Button Down;
    [SerializeField] private List<SummaryControler> summaryControlers;
    [NonSerialized] public int CoeffValue = 1;


    public void OnButtonAddCoeff()
    {
        if (CoeffValue < 9) CoeffValue++;
        CoeffField.text = CoeffValue.ToString();
        foreach(var summaryControler in summaryControlers)
            summaryControler.CalcelateCoeff();
    }

    public void OnButtonSubtractCoeff()
    {
        if (CoeffValue >= 2) CoeffValue--;
        CoeffField.text = CoeffValue.ToString();
        foreach (var summaryControler in summaryControlers)
            summaryControler.CalcelateCoeff();
    }
}
