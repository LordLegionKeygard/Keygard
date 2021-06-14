using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    Collider2D col;

    [SerializeField] private float _time = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    public void Open()
    {       
        animator.SetBool("open", true);
        StartCoroutine(ExecuteAfterTime(_time));
        IEnumerator ExecuteAfterTime(float timeInSec)
        {
            yield return new WaitForSeconds(timeInSec);
            col.enabled = false;
        }
    }

    public void Close()
    {
        animator.SetBool("open", false);
    }
}
