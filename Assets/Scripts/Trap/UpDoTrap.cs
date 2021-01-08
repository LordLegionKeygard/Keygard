using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDoTrap : MonoBehaviour
{
    private int damage = 1;
    private float timeToDamage = 1f;

    private float damageTime;
    private bool isDamage = true;

    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;

    private void Start()
    {
        damageTime = timeToDamage;
        nextPos = startPos.position;
    }

    private void Update()
    {
        if(!isDamage)
        {
            damageTime -= Time.deltaTime;
            if(damageTime <= 0f)
            {
                isDamage = true;
                damageTime = timeToDamage;
            }
        }

        if(transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if(transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
         transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if(playerHealth !=null && isDamage)
        {
            playerHealth.TakeDamage(damage);
            isDamage = false;
        }
    } 

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
