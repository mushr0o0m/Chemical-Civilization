using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [Header("Speeds")]
    [SerializeField] float WalkSpeed = 3;
    [SerializeField] Collider2D ChemicalStation;
    [SerializeField] private Text DialogText;

    private Transform transform;
    private Animator animator;
    private Rigidbody2D rigidbody;
    private Vector2 direction;
    


    private void Start()
    {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("WalkSpeed", direction.magnitude);

    }

    private void FixedUpdate()
    {
        transform.Translate(direction.normalized * WalkSpeed * Time.deltaTime);
    }

    public void MeetNPC (string NPCName, bool isNPCNearby)
    {
        if (isNPCNearby)
            DialogText.text = NPCName;
        else
            DialogText.text = "...";
    }

}