using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : StateMachineBehaviour
{
    private GameObject mira;
    private GameObject[] wayPoints;
    private int currentWP;
    private float speed = 0.5f;

    private void Awake()
    {
        wayPoints = GameObject.FindGameObjectsWithTag("WPMira");
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mira = animator.gameObject;
        currentWP = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (wayPoints.Length == 0 || mira.GetComponent<MiraAreaContraller>().IsPlayerNearby) 
        {
            animator.SetBool("IsMoving", false);
            return;
        } 
        if(Vector2.Distance(wayPoints[currentWP].transform.position,
            mira.transform.position) < 0.05f)
        {
            currentWP++;

            if (currentWP >= wayPoints.Length) currentWP = 0;
        }

        var direction = wayPoints[currentWP].transform.position - mira.transform.position;
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetBool("IsMoving", true);
        mira.transform.Translate(direction.normalized * Time.deltaTime * speed);
    }
}
