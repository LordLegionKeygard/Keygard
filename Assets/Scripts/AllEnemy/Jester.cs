﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jester : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public float walkDistance = 6f;
    public float patrolSpeed = 1f;
    private float chasingSpeed = 0f;
    public float timeToWait = 3f;
    private float timeToChase = 3f;
    private float minDistancetoPlayer = 0f;
    private float moveInput;

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

    public Transform firePoint;
    public GameObject bullet;
    private float nextTime = 0.0f;
    public float timeRate = 1f;

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
        if(isChasingPlayer)
        {
            StartChasingTimer();
        }

        if(isWait && !isChasingPlayer)
        {
            StartWaitTimer();           
        }
        

        if(ShouldWait())
        {
            isWait = true;           
        }
    }

    private void FixedUpdate()
    {             
        nextPoint = Vector2.right * walkSpeed * Time.fixedDeltaTime;
        if(isChasingPlayer && Mathf.Abs(DistanceToPlayer()) < minDistancetoPlayer)
        {
            return;
        }    
   
        if(isChasingPlayer && Time.time > nextTime)
        {
            ChasePlayer();
            animator.SetTrigger("Shoot");                                     
            nextTime = Time.time + timeRate;
            StartCoroutine(ExecuteAfterTime(0.8f));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            Shoot();
            }
        }

        if(!isWait && !isChasingPlayer)
        {
            Patrol();
        }   
    }
    private void Patrol()
    {      
        if(!isFacingRight)
        {
            nextPoint.x *= -1;
        }
        rb.MovePosition((Vector2)transform.position + nextPoint);
    }
    private void ChasePlayer()
    {     
        float distance = DistanceToPlayer() ;
        if(distance < 0)
        {                   
            nextPoint.x *= -1;
        }
        if(distance > 0.2f && !isFacingRight)
        {
            Flip();            
        }
        else if(distance < 0.2f && isFacingRight)
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
        waitTime -= Time.deltaTime;

        if (waitTime < 0f)
        {
            waitTime = timeToWait;
            isWait = false;
            Flip();
        }
    }

    private void StartChasingTimer()
    {      
        chaseTime -= Time.deltaTime;

        if(chaseTime < 0f)
        {
            isChasingPlayer = false;
            chaseTime = timeToChase;
            walkSpeed = patrolSpeed;
            animator.SetTrigger("Idle");

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
        Model.Rotate(0f, 180f, 0f);
    } 

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }   
}
