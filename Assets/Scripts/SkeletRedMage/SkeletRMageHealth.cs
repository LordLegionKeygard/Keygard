﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletRMageHealth : MonoBehaviour
{
    public int health = 3;    
    private Animator animator;

    private UnityEngine.Object explosion;
    private SkeletRedMage enemy;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<SkeletRedMage>();
        explosion = Resources.Load("Explosion");
    }
    public void TakeDamage(int damage)
    {       
        health -= damage;
        animator.SetTrigger("takeDamage");
        if (health <= 0)
        {
            Die();
        }
        if(health == 2 || health == 1)
            {
            enemy.StartChasingPlayer();           
            }
    }

    private void Die()
    {
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Destroy(gameObject);
    }
}
