using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{   
    private Animator animator;

    public Collider2D col;

    public GameObject coin;

    [Header("Slider")]
    public float _health = 1f;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {       
        _health -= damage;
        animator.SetTrigger("open");
        if (_health <= 0)
        {
            StartCoroutine(ExecuteAfterTime(1.1f));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            Die();
            }
        }

    }

    private void Die()
    {
        GameObject coinRef = (GameObject)Instantiate(coin);        
        coinRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        col.enabled = false;
    }
}
