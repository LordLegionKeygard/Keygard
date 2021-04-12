using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private int damage = 100;


    private void OnCollisionEnter2D(Collision2D other) 
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if(playerHealth !=null)
        {
            playerHealth.TakeDamage(damage);
        }
    }     
}
