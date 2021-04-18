using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardController : MonoBehaviour
{

    Animator animator;
    public float speed;
    public float jumpForce;
    public float waterJumpForce;
    private float moveInput;
    private float _normalGravityScale = 2.5f;
    private bool water = false;

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
        if(water == false)
        {
            rb.gravityScale = 2.5f;
        }
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

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0 && water == false || 
           (Input.GetKeyDown(KeyCode.W)) && extraJumps > 0 && water == false  || 
           (Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps > 0 && water == false )
        {              
            if (animator) 
            {
                animator.SetTrigger("Jump");
            }
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded ==true && water == false || 
           (Input.GetKeyDown(KeyCode.W)) && extraJumps == 0 && isGrounded ==true && water == false || 
           (Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps == 0 && isGrounded ==true && water == false )
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpsound.Play();
        }  

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0 && water == true || 
           (Input.GetKeyDown(KeyCode.W)) && extraJumps > 0 && water == true || 
           (Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps > 0 && water == true )
        {              
            animator.SetTrigger("Jump");
            rb.gravityScale = -1f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded ==true && water == true || 
           (Input.GetKeyDown(KeyCode.W)) && extraJumps == 0 && isGrounded ==true && water == true || 
           (Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps == 0 && isGrounded ==true && water == true )
        {
            rb.gravityScale = -1f;
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
        {   speed = 2f;
            StartCoroutine(ExecuteAfterTime(1f));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            speed = 4f;
            }
        }

        if (collision.gameObject.CompareTag("Swamp"))
        { 
            water = true;  
            rb.gravityScale = -0.1f;
        }
        if (collision.gameObject.CompareTag("Bottom"))
        {  
            rb.gravityScale = 0.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Swamp"))
        {
            water = false;
            rb.gravityScale = _normalGravityScale;
        } 

        if (collision.gameObject.CompareTag("Bottom"))
        { 
            rb.gravityScale = 1f;
        }     
    }
}
