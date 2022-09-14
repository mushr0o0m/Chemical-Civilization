using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleHCL : Bottle
{
    private void Awake()
    {
        IsBottleFully = true;
        ReagentSolution reagentSolution = new ReagentSolution();
        Reagents.Add(reagentSolution.HCL.ReagentName, reagentSolution.HCL.SolutionConcentration);
    }
}
