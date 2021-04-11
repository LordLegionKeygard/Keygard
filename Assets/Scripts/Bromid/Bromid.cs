using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bromid : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] private float totalHealth = 15f;
    [SerializeField] private Slider healthSlider;
    private EnemyLoot _enemyLoot;

    [SerializeField] private AudioSource MainMusic;
    [SerializeField] private AudioSource BossMusic;
    [SerializeField] private AudioSource Win;

    Animator animator;

    private int damage = 1;
    private float timeToDamage = 2f;

    private float damageTime;
    private bool isDamage = true;

    public int health = 20;
    private float _health;
    
    private Bromid enemy;
    private UnityEngine.Object explosion;

    public float walkDistance = 6f;
    public float patrolSpeed = 1f;
    private float chasingSpeed = 4f;
    public float timeToWait = 3f;
    private float timeToChase = 3f;
    private float minDistancetoPlayer = 1.5f;
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

    void Start()
    {
        MainMusic.Stop();
        BossMusic.Play();
        _enemyLoot = GetComponent<EnemyLoot>();
        _health = totalHealth;
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();        
        rb = GetComponent<Rigidbody2D>();
        leftBoundaryPosition = transform.position;
        rightBoundaryPosition = leftBoundaryPosition + Vector2.right * walkDistance;
        waitTime = timeToWait;
        chaseTime = timeToChase;
        walkSpeed = patrolSpeed;
        damageTime = timeToDamage;
        enemy = GetComponent<Bromid>();
        explosion = Resources.Load("BossExplosion");
        healthSlider.value = _health / totalHealth;
        InitHealth();           
    }

    private void Update()
    {
        if(!isDamage)
        {
            damageTime -= Time.deltaTime;
            if(damageTime <= 0f)
            {
                isDamage = true;
                damageTime = timeToDamage;
            }
        }
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
        }
        if(!isWait && !isChasingPlayer)
        {
            Patrol();
        }   
    }

    void RandomStatePicker()
    {
        int randomState = Random.Range(0, 4);
        if (randomState == 0)
        {
            animator.SetTrigger("Shoot");
        }
        if (randomState == 1)
        {
            animator.SetTrigger("Attack1");
        }
        if (randomState == 2)
        {
            animator.SetTrigger("Attack2");
        }
        if (randomState == 3)
        {
            animator.SetTrigger("Idle");
        }
    }

    public void AttackShoot()
    {
        if(Time.time > nextTime)
        {                                    
            nextTime = Time.time + timeRate;
            StartCoroutine(ExecuteAfterTime(1f));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);

            Shoot();
            }           
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

    private void OnCollisionStay2D(Collision2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if(playerHealth !=null && isDamage)
        {
            playerHealth.TakeDamage(damage);
            isDamage = false;
        }
    }

    public void TakeDamage(int damage)
    {       
        _health -= damage;
        animator.SetTrigger("takeDamage");
        InitHealth();        
        if (_health <= 0)
        {
            Die();
        }
    }

    private void InitHealth()
    {
        healthSlider.value = _health / totalHealth;
    }

    private void Die()
    {
        _enemyLoot.CalculateLoot();
        BossMusic.Stop();
        Win.Play();
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
        Destroy(gameObject);
    } 
}
