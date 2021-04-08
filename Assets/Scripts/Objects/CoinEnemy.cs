using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEnemy : MonoBehaviour
{
    private Vector3 targetPosition;
    private Rigidbody2D rb;
    private float addGrav = 7;
    private float normalGrav = 2;
    
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        RandomStatePicker();
    }

    private void RandomStatePicker()
    {


        rb.gravityScale -= addGrav;
        int randomState = Random.Range(0, 2);
        if (randomState == 0)
        {
            targetPosition = transform.position + Vector3.left * 1;
            StartCoroutine(ExecuteAfterTime(0.1f));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            Normal();
            }
        }
        else if (randomState == 1)
        {
            targetPosition = transform.position + Vector3.right * 1; 
            StartCoroutine(ExecuteAfterTime(0.1f));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            Normal();
            }         
        }

    }

    private void Normal()
    {
        rb.gravityScale = normalGrav;
    }
}
