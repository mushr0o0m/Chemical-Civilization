using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdle : StateMachineBehaviour
{
    private GameObject mira;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mira = animator.gameObject;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!mira.GetComponent<MiraAreaContraller>().IsPlayerNearby)
        {
            animator.SetBool("IsMoving", true);
            return;
        }
    }
}
