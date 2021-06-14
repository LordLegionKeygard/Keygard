using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private int damage = 1;
    [SerializeField] private Transform checkPoint;
    private Transform target;
    public AudioSource _dieTrap;

    private PlayerHealth _playerHealth;

    private void Start()
    {
        target = GameObject.Find("Ellor").transform;
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(damage);

        if (playerHealth != null && _playerHealth.health >= 1)
        {
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
