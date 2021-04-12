using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoisonBullet : MonoBehaviour
{
    Animator animator;
    public float speed = 5f;
    public int poisonDamage = 1;
    public Rigidbody2D rb;
    public float TimeToLive = 4f;
    private GameObject poisonPanel;

    private float timeToDamage = 3f;
    private float damageTime;
    private bool isDamage = true;

    private void Start()
    {
        poisonPanel = GameObject.Find("/AllCanvas/MobileCanvas/PoisonPanel");
        damageTime = timeToDamage;
        animator = GetComponent<Animator>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, TimeToLive);  
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
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {        
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();

        if (playerHealth != null && isDamage)
        {
            playerHealth.TakePoisonDamage(poisonDamage);
            isDamage = false;
            Die();
        } 
    }   
    

    private void Die()
    {
        StartCoroutine(ExecuteAfterTime(1f));
        IEnumerator ExecuteAfterTime(float timeInSec)
        {
        yield return new WaitForSeconds(timeInSec);
        poisonPanel.SetActive(false);
        }          
    }
}
