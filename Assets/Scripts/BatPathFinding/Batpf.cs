using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batpf : MonoBehaviour
{
    private float moveInput;

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
    }

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();        
        rb = GetComponent<Rigidbody2D>();
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
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }  
}
