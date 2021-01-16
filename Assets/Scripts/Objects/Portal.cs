using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination;

    public bool isPortal;
    
    void Start()
    {        
        if (isPortal == false)
        {
            destination = GameObject.FindGameObjectWithTag("Portal").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("Latrop").GetComponent<Transform>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position) > 1f)
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
        }
    }
}
