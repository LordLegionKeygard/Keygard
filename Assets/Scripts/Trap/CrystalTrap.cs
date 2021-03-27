using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalTrap : MonoBehaviour
{
    private int damage = 1;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (collision.gameObject.CompareTag("Player"))
        {       
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);          
        }                    
    }
}