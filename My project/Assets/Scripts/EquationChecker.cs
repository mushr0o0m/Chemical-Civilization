using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquationChecker : MonoBehaviour
{
    [SerializeField] private List<Text> LeftSideCoeffs;
    [SerializeField] private List<Text> RightSideCoeffs;
    [SerializeField] private GameObject Cross;
    [SerializeField] private GameObject Tab;
    [SerializeField] private GameObject OpenButton;
    [SerializeField] private InterfaceController InterfaceController;
    [SerializeField] private Text ButtomText;

    [NonSerialized] public bool IsGameFinish;
    private void Start()
    {
        OpenButton.SetActive(false);
    }

    public bool IsEquationCorrect()
    {
        for(var i = 0; i < LeftSideCoeffs.Count; i++)
            if (int.Parse(LeftSideCoeffs[i].text) != int.Parse(RightSideCoeffs[i].text))
                return false;
        Cross.SetActive(false);
        ButtomText.text = "Продолжить";
        IsGameFinish = true;
        return true;
    }

    public void CloseTab()
    {
        if (IsGameFinish)
        {
            Tab.SetActive(false);
            InterfaceController.AddCredibility(0.5f);
        } 
    }
}
