﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindWeapon1 : MonoBehaviour
{
    Animator animator;
    public Transform firePoint1;
    public GameObject bullet1;
    private float nextTime = 0.0f;
    public float timeRate = 1f;
    public AudioSource shoot2; 

    private void Start()
    {
        animator = GetComponent<Animator>();                
    }

    void Update()
    {              
        if(Input.GetButtonDown("Fire2") && Time.time > nextTime)
        {  
            animator.SetTrigger("Shoot");                                     
            nextTime = Time.time + timeRate;
            Shoot();
        }        
    }

    public void ShootButtonDown()
    {
        if(Time.time > nextTime)
        {  
            animator.SetTrigger("Shoot");                                     
            nextTime = Time.time + timeRate;
            Shoot();
        }        
    }

    void Shoot()
    {
        Instantiate(bullet1, firePoint1.position, firePoint1.rotation);
        shoot2.Play();
    }
}
