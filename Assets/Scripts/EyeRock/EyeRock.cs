using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRock : MonoBehaviour
{
    private float moveInput;

    private Rigidbody2D rb;
    private Transform playerTransform;

    private bool isFacingRight = true;

    public bool IsFacingRight
    {
        get => isFacingRight;
    }  


    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();        
        rb = GetComponent<Rigidbody2D>();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }    
}
