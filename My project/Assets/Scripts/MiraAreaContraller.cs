using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiraAreaContraller : MonoBehaviour
{
    [SerializeField] GameObject ButtonReactionBoard;
    [SerializeField] GameObject ReactionBoard;
    [SerializeField] EquationChecker equationChecker;
    [NonSerialized] public bool IsPlayerNearby;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterController>() == null)
        {
            throw new NullReferenceException();
        }
        collision.GetComponent<CharacterController>().MeetNPC("Mira", true);
        IsPlayerNearby = true;
        if (!ReactionBoard.activeSelf && !equationChecker.IsGameFinish)
            ButtonReactionBoard.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<CharacterController>().MeetNPC("Mira", false);
        IsPlayerNearby = false;
        ButtonReactionBoard.SetActive(false);
        Debug.Log("Goodbye!");
    }
}
