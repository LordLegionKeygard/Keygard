using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    Animator animator;
    public float walkDistance = 6f;
    public float patrolSpeed = 1f;
    private float chasingSpeed = 0f;
    public float timeToWait = 3f;
    private float timeToChase = 3f;
    private float minDistancetoPlayer = 0f;
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

    private float time = 1f;
    public Transform firePoint;
    public GameObject bullet;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;
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
        animator = GetComponent<Animator>();
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
            StartCoroutine(ExecuteAfterTime(1.5f));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            RandomStatePicker();
            }
        }

        if(!isWait && !isChasingPlayer)
        {
            Patrol();
        }   
    }

    void RandomStatePicker()
    {
        int randomState = Random.Range(0, 6);
        if (randomState == 0)
        {
            Shoot();
        }
        if (randomState == 1)
        {
            Shoot1();
        }
        if (randomState == 2)
        {
            Shoot2();
        }
        if (randomState == 3)
        {
            Shoot3();
        }
        if (randomState == 4)
        {
            Shoot4();
        }
        else if (randomState == 5)
        {
            Shoot5();            
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
            animator.SetTrigger("Idle");
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
        transform.Rotate(0f, 180f, 0f);
    } 

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void Shoot1()
    {
        Instantiate(bullet1, firePoint.position, firePoint.rotation);
    }  

    void Shoot2()
    {
        Instantiate(bullet2, firePoint.position, firePoint.rotation);
    } 

    void Shoot3()
    {
        Instantiate(bullet3, firePoint.position, firePoint.rotation);
    } 

    void Shoot4()
    {
        Instantiate(bullet4, firePoint.position, firePoint.rotation);
    }

    void Shoot5()
    {
        Instantiate(bullet5, firePoint.position, firePoint.rotation);
    }
}
