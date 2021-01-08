﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalU : MonoBehaviour
{
    Animator animator;
    private int damage = 6;
    private float timeToDamage = 1f;

    private float damageTime;
    private bool isDamage = true;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
            if(animator)
            {
                
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