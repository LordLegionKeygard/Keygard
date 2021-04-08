using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrindMur : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] private float totalHealth = 15f;
    [SerializeField] private Slider healthSlider;
    private EnemyLoot _enemyLoot;
    [SerializeField] private GameObject _trap;
    [SerializeField] private GameObject _mplatform;

    [SerializeField] private AudioSource MainMusic;
    [SerializeField] private AudioSource BossMusic;
    [SerializeField] private AudioSource Win;

    private Rigidbody2D enemyRB;
    private Animator enemyAnim;

    private int damage = 1;
    private float timeToDamage = 2f;

    private float damageTime;
    private bool isDamage = true;

    public int health = 20;
    private float _health;
    
    private GrindMur enemy;
    private UnityEngine.Object explosion;

    private float time = 1f;
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;
    public Transform firePoint6;
    public GameObject bullet;
    public GameObject bullet2;
    private float nextTime = 0.0f;
    public float timeRate = 1f;


    void Start()
    {
        _mplatform.SetActive(false);
        _trap.SetActive(false);
        MainMusic.Stop();
        BossMusic.Play();
        _enemyLoot = GetComponent<EnemyLoot>();
        _health = totalHealth;
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        damageTime = timeToDamage;
        enemy = GetComponent<GrindMur>();
        explosion = Resources.Load("BossExplosion");
        healthSlider.value = _health / totalHealth;
        InitHealth();
    }

    void Update()
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
    }

    void RandomStatePicker()
    {
        int randomState = Random.Range(0, 3);
        if (randomState == 0)
        {
            enemyAnim.SetTrigger("Shoot");
        }
        if (randomState == 1)
        {
            enemyAnim.SetTrigger("Pick");
        }
        else if (randomState == 2)
        {
            enemyAnim.SetTrigger("AttackPlayer");
        }
    }

    public void AttackPlayerState()
    {
        enemyAnim.SetTrigger("Slam");       
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
            Shoot1();
            Shoot2();
            }           
        }        
    }
    public void Pick()
    {
        if(Time.time > nextTime)
        {                                    
            nextTime = Time.time + timeRate;
            StartCoroutine(ExecuteAfterTime(1f));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);            
            Shoot3();
            Shoot4();
            Shoot5();
            Shoot6(); 
            }          
        }        
    }


    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
    void Shoot1()
    {
        Instantiate(bullet, firePoint1.position, firePoint1.rotation);
    }
    void Shoot2()
    {
        Instantiate(bullet, firePoint2.position, firePoint2.rotation);        
    }

    void Shoot3()
    {
        Instantiate(bullet2, firePoint3.position, firePoint3.rotation);
    }
    void Shoot4()
    {
        Instantiate(bullet2, firePoint4.position, firePoint4.rotation);
    }
    void Shoot5()
    {
        Instantiate(bullet2, firePoint5.position, firePoint5.rotation);        
    }
    void Shoot6()
    {
        Instantiate(bullet2, firePoint6.position, firePoint6.rotation);         
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
