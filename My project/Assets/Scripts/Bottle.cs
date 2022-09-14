using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bottle : MonoBehaviour
{
    public Dictionary<string, float> Reagents = new Dictionary<string, float>();
    [SerializeField] private GameObject bottleContent;
    [SerializeField] private Image BottleContent;
    private float contentValue = 0f;
    public float ContentValue
    {
        get => contentValue;
        set
        {
            contentValue = value;
            AddContentBottle(contentValue);
            Debug.Log(contentValue);
        }
    }
    public bool IsBottleFully;
    public bool IsEmpty { 
        get
        {
            bottleContent.SetActive(Reagents == null);
            return Reagents == null ; 
        } 
    }

    public Bottle()
    {
    } 

    public Bottle(params Reagent[] reagent)
    {
        foreach (var e in reagent)
        {
            if (Reagents.ContainsKey(e.ReagentName))
                Reagents[e.ReagentName] = (Reagents[e.ReagentName] + e.SolutionConcentration) / 2f;
            else
                Reagents.Add(e.ReagentName, e.SolutionConcentration);
        }
    }

    public void AddReagents(params Reagent[] reagent)
    {
        foreach (var e in reagent)
        {
            if (Reagents.ContainsKey(e.ReagentName))
                Reagents[e.ReagentName] = (Reagents[e.ReagentName] + e.SolutionConcentration) / 2f;
            else
                Reagents.Add(e.ReagentName, e.SolutionConcentration);
        }
    }

    private void AddContentBottle(float value)
    {
        BottleContent.fillAmount = value;
    }
}
