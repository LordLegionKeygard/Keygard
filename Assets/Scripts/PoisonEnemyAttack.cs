using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEnemyAttack : MonoBehaviour
{
    Animator animator;
    private int _poisonDamage = 1;
    private float timeToDamage = 1f;

    private float damageTime;
    private bool isDamage = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        damageTime = timeToDamage;
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
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if(playerHealth !=null && isDamage)
        {
            playerHealth.TakePoisonDamage(_poisonDamage);
            isDamage = false;
        }
    } 
}
