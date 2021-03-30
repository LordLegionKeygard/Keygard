using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatpfHealth : MonoBehaviour
{
    public int health = 2;    
    private Animator animator;

    private UnityEngine.Object explosion;

    private void Start()
    {
        animator = GetComponent<Animator>();
        explosion = Resources.Load("Explosion1");
    }
    public void TakeDamage(int damage)
    {       
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Destroy(gameObject);
    }
}
