using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    Animator  animator;

    public float _rainTime;

    private void Start() 
    {
        animator = GetComponent<Animator>();
        RandomStatePicker();       
    }

    void RandomStatePicker()
    {
    
        int randomState = Random.Range(0, 2);
        if (randomState == 0)
        {
            animator.SetBool("rain", true);
            StartCoroutine(ExecuteAfterTime(_rainTime));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            RandomStatePicker();
            }

        }
        if (randomState == 1)
        {
            animator.SetBool("rain", false);
            StartCoroutine(ExecuteAfterTime(_rainTime));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            RandomStatePicker();
            }
        }        
    }
}
