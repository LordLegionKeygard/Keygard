using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    Animator animator;
    Collider2D col;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        col.enabled = false;
        animator.SetBool("open", true);  
    }

    public void Close()
    {        
        col.enabled = true;
        animator.SetBool("open", false);
    }
}
