using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletRMageBullet : MonoBehaviour
{
    Animator animator;
    public float speed = 5f;
    public int damage = 1;
    public Rigidbody2D rb;
    public float TimeToLive = 4f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, TimeToLive);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {        
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
           
        Destroy(gameObject);        
    }
}
