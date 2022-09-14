using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Reagent : MonoBehaviour
{
    public float SolutionConcentration { get; set; }
    public string ReagentName { get; private set; }

    public Reagent(float solutionConcentration, string reagentName)
    {
        ReagentName = reagentName;
        SolutionConcentration = solutionConcentration;
    }

}
