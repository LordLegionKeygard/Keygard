using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmMushBullet : MonoBehaviour
{
    Animator animator;
    public float speed = 0f;
    public int poisonDamage = 1;
    public Rigidbody2D rb;
    public float TimeToLive = 1f;
    private GameObject poisonPanel;


    private void Start()
    {
        poisonPanel = GameObject.Find("/AllCanvas/MobileCanvas/PoisonPanel");
        animator = GetComponent<Animator>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, TimeToLive);  
    }




    private void OnTriggerEnter2D(Collider2D hitInfo)
    {        
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakePoisonDamage(poisonDamage);
            Die();
        }   
    }

    private void Die()
    {
        StartCoroutine(ExecuteAfterTime(0.8f));
        IEnumerator ExecuteAfterTime(float timeInSec)
        {
        yield return new WaitForSeconds(timeInSec);
        poisonPanel.SetActive(false);
        }          
    }
}
