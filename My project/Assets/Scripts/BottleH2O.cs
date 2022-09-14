using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleH2O : Bottle
{
    private void Awake()
    {
        IsBottleFully = true;
        ReagentSolution reagentSolution = new ReagentSolution();
        Reagents.Add(reagentSolution.H2O.ReagentName, reagentSolution.H2O.SolutionConcentration);
    }
}
