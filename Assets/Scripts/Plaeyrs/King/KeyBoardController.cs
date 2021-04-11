using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardController : MonoBehaviour
{

    Animator animator;
    public float speed;
    public float jumpForce;
    private float moveInput;

    public GameObject _platform;

    [Header("Music Effect")]
    public AudioSource jumpsound;
         
    private Rigidbody2D rb;

    public bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float chekRadius;
    public LayerMask whatIsGround; 


    private int extraJumps;
    public int extraJumpsValue;

    private void Start()
    {
        animator = GetComponent<Animator>();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {   
                
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, chekRadius, whatIsGround);                  

        moveInput = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
        if (animator)
        {
            animator.SetBool("Walk", Mathf.Abs(moveInput) >= 0.1f);
        }

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        } 
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _platform.SetActive(false);

            StartCoroutine(ExecuteAfterTime(0.5f));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            _platform.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0 || 
           (Input.GetKeyDown(KeyCode.W)) && extraJumps > 0 || 
           (Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps > 0)
        {              
            if (animator) 
            {
                animator.SetTrigger("Jump");
            }
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded ==true || 
           (Input.GetKeyDown(KeyCode.W)) && extraJumps == 0 && isGrounded ==true || 
           (Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps == 0 && isGrounded ==true)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpsound.Play();
        }                  
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("QuickSand"))
        {
            speed = 1f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("QuickSand"))
        {
            speed = 4f;
        }      
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("PoisonBullet"))
        {
            speed = 1f;
            StartCoroutine(ExecuteAfterTime(1f));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            speed = 4f;
            }
        }
    }
}
