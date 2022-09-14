using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReagentSolution : MonoBehaviour
{
    public Reagent H2O
    {
        get
        {
            return new Reagent(1f, "H2O");
        }
    }

    public Reagent HCL
    {
        get
        {
            return new Reagent(0.75f, "HCL");
        }
    }
}
