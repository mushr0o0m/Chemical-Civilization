using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBottle : Bottle
{
    private void Awake()
    {
        IsBottleFully = false;
        ContentValue = 0;
    }
}
