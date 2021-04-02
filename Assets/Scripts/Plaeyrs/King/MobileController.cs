using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{

    Animator animator;
    public float speed;
    public float jumpForce;
    private float moveInput;
    public float normalspeed;

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
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }                      
    }

    public void OnJumpButtonDown()
    {
        if(extraJumps > 0)
        {
        animator.SetTrigger("Jump");           
        rb.velocity = Vector2.up * jumpForce;
        extraJumps--;
        }

        if(extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
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
}
