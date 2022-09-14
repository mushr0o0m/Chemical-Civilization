using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    [SerializeField] GameObject Interface;
    [SerializeField] private List<GameObject> Quests;
    [SerializeField] private Image CredibilityScale;
    private float credibilityScore = 0.1f;

    private void Start()
    {
        CredibilityScale.fillAmount = credibilityScore;
        credibilityScore = 0;
    }
    private void Update()
    {
        var isQuestOpen = false;
        foreach (var quest in Quests) 
        {
            if (quest.activeSelf)
            {
                isQuestOpen = true;
            }
        }
        Interface.SetActive(!isQuestOpen);
    }

    public void AddCredibility(float amount)
    {
        if (amount > 1 || amount < 0)
            Debug.LogError("Amount credibility score has an invalid value");
        credibilityScore += amount;
        CredibilityScale.fillAmount = credibilityScore;
    }
}
