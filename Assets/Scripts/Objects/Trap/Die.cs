using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private int damage = 1;
    [SerializeField] private Transform checkPoint;
    private Transform target;
    public AudioSource _dieTrap;

    private void Start()
    {
        target = GameObject.Find("King").transform;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            
            _dieTrap.Play();
            StartCoroutine(ExecuteAfterTime(0.5f));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
                yield return new WaitForSeconds(timeInSec);
                target.transform.position = new Vector2(checkPoint.position.x, checkPoint.position.y);
            }
        }
    }
}
