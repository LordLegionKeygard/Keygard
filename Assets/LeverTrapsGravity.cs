using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrapsGravity : MonoBehaviour
{
    Rigidbody2D rb;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
            StartCoroutine(ExecuteAfterTime(3f));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            Die();
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
