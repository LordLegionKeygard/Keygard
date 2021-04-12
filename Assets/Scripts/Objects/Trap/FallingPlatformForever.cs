using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformForewer : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 currentPosition;  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("FallPlatform", 0.3f);
            Destroy(gameObject, 1.5f);
        }
    }

    void FallPlatform()
    {
        rb.isKinematic = false;
    }
   
}
