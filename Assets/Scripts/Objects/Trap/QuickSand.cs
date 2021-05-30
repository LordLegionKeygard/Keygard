using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSand : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 currentPosition;
    bool moveingBack = false;   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && moveingBack == false)
        {
            FallPlatform();           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BackPlatform();
        }     
    }

    void FallPlatform()
    {
        rb.isKinematic = false;
    }

    void BackPlatform()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        moveingBack = true;
    }

    private void Update()
    {
        if (moveingBack == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPosition, 20f * Time.deltaTime);
        }

        if (transform.position.y == currentPosition.y && transform.position.z == currentPosition.z)
        {
            moveingBack = false;
        }
    }
   
}
