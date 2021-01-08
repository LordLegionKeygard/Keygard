using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private int damage = 100;
    private float timeToDamage = 1f;

    private float damageTime;
    private bool isDamage = true;
    private Rigidbody2D rb;

    private void Start()
    {
        damageTime = timeToDamage;
        rb = GetComponent<Rigidbody2D>();
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

    private void OnCollisionStay2D(Collision2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if(playerHealth !=null && isDamage)
        {
            playerHealth.TakeDamage(damage);
            isDamage = false;
        }
    }         
}
