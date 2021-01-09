using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Animator animator;
    public float speed;
    public float jumpForce;
    private float moveInput;

    public GameObject PStaff;
    public GameObject Skillj;
    public GameObject Skillk;
    public GameObject Skilll;
    public GameObject PSKghost1;
    public GameObject PSkghost2;
    public GameObject PSkghost3;
    public AudioSource jumpsound;
    public AudioSource PickUpStaff;
    public AudioSource PickUpScroll; 
         
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


        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0 || (Input.GetKeyDown(KeyCode.W)) && extraJumps > 0 || (Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps > 0)
        {              
            if (animator) 
            {
                animator.SetTrigger("Jump");
            }
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded ==true || (Input.GetKeyDown(KeyCode.W)) && extraJumps == 0 && isGrounded ==true || (Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps == 0 && isGrounded ==true)
        {
            jumpsound.Play();
        }        
       
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded ==true || (Input.GetKeyDown(KeyCode.W)) && extraJumps == 0 && isGrounded ==true || (Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps == 0 && isGrounded ==true)
        {
            
            rb.velocity = Vector2.up * jumpForce;
        }
           
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }   

    private void OnTriggerEnter2D(Collider2D other)
    {      
        if(other.gameObject.name == "PoisonStaff")
        {
            PickUpStaff.Play();           
            Destroy(other.gameObject);
            var myscript = gameObject.GetComponent<Weapon>();       
            myscript.enabled = true;
            PStaff.SetActive(true);
            Skillk.SetActive(true);
            PSkghost2.SetActive(true);
        }
        
        if(other.gameObject.name == "LScroll")
        {
            PickUpScroll.Play();           
            Destroy(other.gameObject);
            var myscript = gameObject.GetComponent<Weapon1>();       
            myscript.enabled = true;
            Skilll.SetActive(true);
            PSkghost3.SetActive(true);
        }

        if(other.gameObject.name == "JScroll")
        {
            PickUpScroll.Play();
            Destroy(other.gameObject);
            var myscript = gameObject.GetComponent<Weapon2>();
            myscript.enabled = true;
            Skillj.SetActive(true);
            PSKghost1.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision. gameObject.CompareTag("Platform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision. gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null;
        }        
    }
}
