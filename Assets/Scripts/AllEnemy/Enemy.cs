﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public float walkDistance = 6f;
    public float patrolSpeed = 1f;
    public float chasingSpeed = 3.2f;
    public float timeToWait = 3f;
    private float timeToChase = 3f;
    public float minDistancetoPlayer = 1.5f;
    public float minDinstanceToAttack = 4f;
    private float moveInput;
    bool walk = true;

    [SerializeField] private Transform Model;

    private Rigidbody2D rb;
    private Transform playerTransform;
    private Vector2 leftBoundaryPosition;
    private Vector2 rightBoundaryPosition;
    private Vector2 nextPoint;

    private bool isFacingRight = true;
    private bool isWait = false;
    private bool isChasingPlayer;

    private float walkSpeed;
    private float waitTime;
    private float chaseTime;

    public bool IsFacingRight
    {
        get => isFacingRight;
    }

    public void StartChasingPlayer()
    {
        isChasingPlayer = true;
        chaseTime = timeToChase;
        walkSpeed = chasingSpeed;
    }

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        leftBoundaryPosition = transform.position;
        rightBoundaryPosition = leftBoundaryPosition + Vector2.right * walkDistance;
        waitTime = timeToWait;
        chaseTime = timeToChase;
        walkSpeed = patrolSpeed;
    }

    private void Update()
    {
        if (isChasingPlayer)
        {
            StartChasingTimer();
        }

        if (isWait && !isChasingPlayer)
        {
            StartWaitTimer();
        }


        if (ShouldWait())
        {
            isWait = true;
        }

        if (isChasingPlayer && Mathf.Abs(DistanceToPlayer()) < minDinstanceToAttack)
        {
            animator.SetTrigger("Attack");
        }
    }

    private void FixedUpdate()
    {
        nextPoint = Vector2.right * walkSpeed * Time.fixedDeltaTime;

        if (isChasingPlayer && Mathf.Abs(DistanceToPlayer()) < minDistancetoPlayer)
        {
            return;
        }

        if (animator)
        {
            animator.SetBool("Walk", walk);
        }

        if (isChasingPlayer)
        {
            ChasePlayer();
        }

        if (!isWait && !isChasingPlayer)
        {
            Patrol();
        }

    }

    private void Patrol()
    {
        if (!isFacingRight)
        {
            nextPoint.x *= -1;
        }
        rb.MovePosition((Vector2)transform.position + nextPoint);
    }
    private void ChasePlayer()
    {
        walk = true;
        float distance = DistanceToPlayer();
        if (distance < 0)
        {
            nextPoint.x *= -1;
        }
        if (distance > 0.2f && !isFacingRight)
        {
            Flip();
        }
        else if (distance < 0.2f && isFacingRight)
        {
            Flip();
        }

        rb.MovePosition((Vector2)transform.position + nextPoint);
    }

    private float DistanceToPlayer()
    {
        return playerTransform.position.x - transform.position.x;
    }

    private void StartWaitTimer()
    {
        walk = false;
        waitTime -= Time.deltaTime;

        if (waitTime < 0f)
        {
            waitTime = timeToWait;
            isWait = false;
            walk = true;
            Flip();
        }
    }

    private void StartChasingTimer()
    {
        chaseTime -= Time.deltaTime;

        if (chaseTime < 0f)
        {
            isChasingPlayer = false;
            chaseTime = timeToChase;
            walkSpeed = patrolSpeed;
        }
    }


    private bool ShouldWait()
    {
        bool isOutOfRightBoundary = isFacingRight && transform.position.x >= rightBoundaryPosition.x;
        bool isOutOfLeftBoundary = !isFacingRight && transform.position.x <= leftBoundaryPosition.x;

        return isOutOfLeftBoundary || isOutOfRightBoundary;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(leftBoundaryPosition, rightBoundaryPosition);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 playerScale = Model.localScale;
        playerScale.x *= -1;
        Model.localScale = playerScale;
    }
}
