using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    public AudioSource _gateSound;
    private bool _gate = true;

    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _gate == true)
        {
            _gateSound.Play();
            animator.SetTrigger("Chain");
            _gate = false;         
        }
    }
}
