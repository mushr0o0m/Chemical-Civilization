using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryControler : MonoBehaviour
{
    [SerializeField] private Text Element;
    [SerializeField] private Text Amount;
    [SerializeField] private List<ChemicalElement> chemicalElements;
    [SerializeField] private EquationChecker equationChecker;

    private void Start()
    {
        int amountStart = 0;
        foreach (var chemicalElement in chemicalElements)
            for (var i = 0; i < chemicalElement.Elements.Count; i++)
            {
                if (chemicalElement.Elements[i] == Element.text)
                {
                    amountStart += chemicalElement.Index[i] * chemicalElement.CoefficientÑontrol.CoeffValue;
                }

            }

        Amount.text = amountStart.ToString();
    }

    public void CalcelateCoeff()
    {
        var amount = 0;
        foreach (var chemicalElement in chemicalElements)
            for (var i = 0; i < chemicalElement.Elements.Count; i++)
            {
                if (chemicalElement.Elements[i] == Element.text)
                {
                    amount += chemicalElement.Index[i] * chemicalElement.CoefficientÑontrol.CoeffValue;
                }

            }
        Amount.text = amount.ToString();
        equationChecker.IsEquationCorrect();
    }
}
