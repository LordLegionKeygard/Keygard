using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{

    Animator animator;
    public float speed;
    public float jumpForce;
    public float normalspeed;
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
        speed = 0f;
        animator = GetComponent<Animator>();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {   
                
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, chekRadius, whatIsGround);                  
        
        rb.velocity = new Vector2(speed, rb.velocity.y);
        
        if (speed != 0)
        {
            animator.SetBool("Walk", true);
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
    }

    public void OnJumpButtonDown()
    {
        if(extraJumps > 0 && water == false)
        {
        animator.SetTrigger("Jump");           
        rb.velocity = Vector2.up * jumpForce;
        extraJumps--;
        }

        if(extraJumps == 0 && isGrounded == true && water == false)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpsound.Play();
        }

        if(extraJumps > 0 && water == true)
        {
        animator.SetTrigger("Jump");           
        rb.gravityScale = -1f;
        }

        if(extraJumps == 0 && isGrounded == true && water == true)
        {
            rb.gravityScale = -1f;
            jumpsound.Play();
        }
    }

    public void OnLeftButtonDown()
    {
        if(speed >= 0f)
        {
            speed = -normalspeed;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void OnRightButtonDown()
    {
        if(speed <= 0f)
        {
            speed = normalspeed;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void OnButtonUp()
    {
        speed = 0f;
        animator.SetBool("Walk", false);
    }

    public void OnButtonDown()
    {
        _platform.SetActive(false);

        StartCoroutine(ExecuteAfterTime(0.5f));
        IEnumerator ExecuteAfterTime(float timeInSec)
        {
        yield return new WaitForSeconds(timeInSec);
        _platform.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
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
