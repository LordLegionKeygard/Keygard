using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWeapon1 : MonoBehaviour
{
    Animator animator;
    private float time = 1f;
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
            shoot2.Play();  
            animator.SetTrigger("Shoot");                                     
            nextTime = Time.time + timeRate;
            Shoot();
        }        
    }

    void Shoot()
    {
        Instantiate(bullet1, firePoint1.position, firePoint1.rotation);
    }
}
