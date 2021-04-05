using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    Animator animator;
    private float time = 1f;
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject bullet;
    private float nextTime = 0.0f;
    public float timeRate = 1f;
    public AudioSource shoot3;

    private void Awake()
    {
        animator = GetComponent<Animator>();                
    }

    void Update()
    {                     
        if(Input.GetButtonDown("Fire3") && Time.time > nextTime)
        { 
            animator.SetTrigger("Shoot");                                     
            nextTime = Time.time + timeRate;
            Shoot();
            Shoot2();
            Shoot3();
        }
    }

    public void ShootButtonDown()
    {
        if(Time.time > nextTime)
        {  
            animator.SetTrigger("Shoot");                                     
            nextTime = Time.time + timeRate;
            Shoot();
            Shoot2();
            Shoot3();
        }        
    }
    
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        shoot3.Play(); 
    }

    void Shoot2()
    {
        Instantiate(bullet, firePoint1.position, firePoint1.rotation);
    }

    void Shoot3()
    {
        Instantiate(bullet, firePoint2.position, firePoint2.rotation);
    }      
}