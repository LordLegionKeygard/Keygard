using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWeapon : MonoBehaviour
{
    Animator animator;
    private float time = 1f;
    public Transform firePoint;
    public GameObject bullet;
    private float nextTime = 0.0f;
    public float timeRate = 1f;
    public AudioSource shoot;


    private void Start()
    {
        animator = GetComponent<Animator>();                
    }

    void Update()
    {              
        if(Input.GetButtonDown("Fire1") && Time.time > nextTime)
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
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        shoot.Play();
    }
}
