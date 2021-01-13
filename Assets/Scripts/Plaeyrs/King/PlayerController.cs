using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    Animator animator;
    public float speed;
    public float jumpForce;
    private float moveInput;

    public GameObject onehealth;
    public GameObject twohealth;

    [Header("FireStaff")]
    public GameObject FStaff;
    public GameObject FSkillj;
    public GameObject FSkillk;
    public GameObject FSkilll;
    public GameObject FSkghost1;
    public GameObject FSkghost2;
    public GameObject FSkghost3;


    [Header("PoisonStaff")]
    public GameObject PStaff;
    public GameObject PSkillj;
    public GameObject PSkillk;
    public GameObject PSkilll;
    public GameObject PSkghost1;
    public GameObject PSkghost2;
    public GameObject PSkghost3;

    [Header("Music Effect")]
    public AudioSource jumpsound;
    public AudioSource PickUpStaff;
    public AudioSource PickUpScroll; 
         
    private Rigidbody2D rb;
    private GameObject finish;

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
        finish = GameObject.FindGameObjectWithTag("Finish");
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
        if(other.gameObject.name == "RandomStaff")
        {
            PickUpStaff.Play();           
            Destroy(other.gameObject);
            RandomStatePicker();            
        }
        
        if(other.gameObject.name == "LScroll")
        {
            PickUpScroll.Play();           
            Destroy(other.gameObject);
            var myscript = gameObject.GetComponent<Weapon1>();
            var fmyscript = gameObject.GetComponent<FireWeapon1>();
            if(PStaff.activeInHierarchy)
            {      
                myscript.enabled = true;
                PSkilll.SetActive(true);
                PSkghost3.SetActive(true);
            }
            if(FStaff.activeInHierarchy)
            {
                fmyscript.enabled = true;
                FSkilll.SetActive(true);
                FSkghost3.SetActive(true);
            }
        }

        if(other.gameObject.name == "JScroll")
        {
            PickUpScroll.Play();
            Destroy(other.gameObject);
            var myscript = gameObject.GetComponent<Weapon2>();
            if(PStaff.activeInHierarchy)
            {           
                myscript.enabled = true;
                PSkillj.SetActive(true);
                PSkghost1.SetActive(true);
            }
            if(FStaff.activeInHierarchy)
            {
                
            }

        }
        if(other.gameObject.CompareTag("BulletEnemy"))
        {
            onehealth.SetActive(true);
            StartCoroutine(ExecuteAfterTime(1));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            onehealth.SetActive(false);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = collision.transform;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
        if (collision.gameObject.CompareTag("Enemy") || 
            collision.gameObject.CompareTag("Trap1") ||
            collision.gameObject.CompareTag("GruzMother"))
        {
            onehealth.SetActive(true);

            StartCoroutine(ExecuteAfterTime(1));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            onehealth.SetActive(false);
            }          
        }
        if (collision.gameObject.CompareTag("Trap2"))
            
        {
            twohealth.SetActive(true);

            StartCoroutine(ExecuteAfterTime(1));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            twohealth.SetActive(false);
            }          
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null;
        }      
    }

    void RandomStatePicker()
    {
        int randomState = Random.Range(0, 2);
        if (randomState == 0)
        {
            var myscript = gameObject.GetComponent<Weapon>();       
            myscript.enabled = true;
            PStaff.SetActive(true);
            PSkillk.SetActive(true);
            PSkghost2.SetActive(true);
        }
        else if (randomState == 1)
        {
            var myscript = gameObject.GetComponent<FireWeapon>();
            myscript.enabled = true;
            FStaff.SetActive(true);
            FSkillk.SetActive(true);
            FSkghost2.SetActive(true);            
        }
    }
}
